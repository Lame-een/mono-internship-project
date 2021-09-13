using System;
using System.Xml;
using Lyre.Common;
using Lyre.Model.Common;
using Lyre.Service.Common;
using System.Web.Hosting;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lyre.Service
{
    public class Authenticator : IAuthenticator
    {
        //obvious attack vector, a better way to authenticate would probably be OAuth, saving tokens in DB or similar
        private string _keyPath = HostingEnvironment.MapPath(@"~/App_Data/authkey.xml");
        private string _authKey;
        private DateTime _creationTime;

        protected IUserService Service { get; }

        private void CreateKey()
        {
            byte[] salt = null;
            _authKey = CryptoProvider.GenerateSalt(ref salt, 32);
            _creationTime = DateTime.Now;

            using (XmlWriter writer = XmlWriter.Create(_keyPath))
            {
                writer.WriteStartElement("authkey");

                writer.WriteElementString("key", _authKey);
                writer.WriteElementString("creationTime", _creationTime.ToString());

                writer.WriteEndElement();
                writer.Flush();
            }
        }

        private string ReadKey()
        {
            //check validity of current saved key
            if ((_authKey != null) && ((DateTime.Now.Date - _creationTime.Date) < TimeSpan.FromDays(1)))
            {
                return _authKey;
            }

            if (!File.Exists(_keyPath))
            {
                CreateKey();
                return _authKey;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(_keyPath);

            XmlElement root = doc.DocumentElement;
            if (root.Name != "authkey")
            {
                CreateKey();
                return _authKey;
            }

            XmlNodeList nodes = root.ChildNodes;

            if ((nodes.Count == 2) && (nodes[0].Name == "key") && (nodes[1].Name == "creationTime")) //check validity of xml
            {
                try
                {
                    DateTime keyTime = DateTime.Parse(nodes[1].InnerText);
                    if ((DateTime.Now.Date - keyTime.Date) > TimeSpan.FromDays(1))
                    {
                        throw new Exception("Key has expired.");
                    }

                    _authKey = nodes[0].InnerText;
                    _creationTime = keyTime;
                }
                catch (Exception)
                {
                    CreateKey();
                }
            }
            else
            {
                CreateKey();
            }
            return _authKey;
        }

        public async Task<IUser> AuthenticateAsync(System.Net.Http.Headers.AuthenticationHeaderValue authHeader)
        {
            string token = authHeader.Parameter;
            return await AuthenticateAsync(token);
        }

        public async Task<IUser> AuthenticateAsync(string token)
        {
            try
            {
                string decrypted = Convert.ToBase64String(CryptoProvider.Decrypt(token, ReadKey()));
                Guid id = Guid.Parse(decrypted);

                return await Service.SelectUserAsync(id);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool Authenticate(string token, ref Guid? id)
        {
            try
            {
                string decrypted = Convert.ToBase64String(CryptoProvider.Decrypt(token, ReadKey()));
                id = Guid.Parse(decrypted);

                return true;
            }
            catch (Exception)
            {
                id = null;
                return false;
            }

        }

        public string CreateToken(Guid userid)
        {
            string id = userid.ToString().Replace("-", string.Empty);

            string token;

            try
            {
                token = Convert.ToBase64String(CryptoProvider.Encrypt(id, ReadKey()));
            }
            catch(Exception)
            {
                CreateKey();
                token = Convert.ToBase64String(CryptoProvider.Encrypt(id, ReadKey()));
            }

            return token;
        }

        public Authenticator(IUserService service)
        {
            Service = service;
            ReadKey();
        }
    }
}
