using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Model.Common;

namespace Lyre.Model
{
    public class User : IUser
    {
        public const int FieldNumber = 6;
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }
        public DateTime? CreationTime { get; set; }

        public User(Guid id, string username)
        {
            UserID = id;
            Username = username;
            Role = UserRole.USER;
            CreationTime = DateTime.Now;
        }
        public User(string username)
        {
            UserID = Guid.NewGuid();
            Username = username;
            Role = UserRole.USER;
            CreationTime = DateTime.Now;
        }

        public User(object[] obj)
        {
            if (obj.Length < FieldNumber) throw new ArgumentException("Passed object array is not of valid length");

            UserID = (Guid)obj[0];
            Username = (string)obj[1];
            Hash = (string)obj[2];
            Salt = (string)obj[3];
            Role = (UserRole)Enum.Parse(typeof(UserRole), (string)obj[4]);
            CreationTime = (DateTime?)(obj[5] == DBNull.Value ? null : obj[5]);
        }
    }
}
