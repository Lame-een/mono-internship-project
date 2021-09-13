using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Common
{

    public class QueryStringManager
    {
        public Sorter Sorter { get; }
        public Pager Pager { get; }
        public Filter Filter { get; }
        public static Dictionary<string, string> ToDictionary(NameValueCollection nvc)
        {
            var dictionary = new Dictionary<string, string>();

            foreach (var k in nvc.AllKeys)
            {
                dictionary.Add(k, nvc[k]);
            }
            return dictionary;
        }

        public QueryStringManager(NameValueCollection uriNvc)
        {
            var uriDictionary = ToDictionary(uriNvc);
            Filter = new Filter(uriDictionary);
            Sorter = new Sorter(uriDictionary);
            Pager = new Pager(uriDictionary);
        }
    }
}
