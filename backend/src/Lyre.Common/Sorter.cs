using System;
using System.Collections.Generic;
using System.Linq;

namespace Lyre.Common
{
    public class Sorter
    {
        public enum OrderType : byte
        {
            ASC = 0,
            DESC = 1
        }
        public OrderType Order { get; set; }
        public string Sort { get; set; }

        private string _sqlString = null;

        ///<summary>
        ///Checks if the stored <strong>Sort</strong> property is contained in a 
        ///column of the <strong>type</strong> model class.
        ///</summary>
        ///<example>Example usage:
        ///<code>
        /// Sorter sorter = new Sorter("name");
        /// sorter.InitializeSql(typeof(ISong));
        /// 
        /// ...
        /// 
        /// string sqlSelect = "SELECT * FROM song" + filter.GetSql() + sorter.GetSql() + pager.GetSql() + ';';
        /// </code>
        ///</example>
        ///<param name="type">Type of the Model object which is being sorted</param>
        ///<returns><strong>string</strong> SQL command snippet</returns>
        public string InitializeSql(Type type)
        {
            if (Sort == null)
                return _sqlString = String.Format(" ORDER BY (SELECT NULL) {0} ", Order.ToString());

            var names = (from name in type.GetProperties() select name.Name.ToLower());

            if (names.Contains(Sort.ToLower()))
            {
                return _sqlString = String.Format(" ORDER BY {0} {1} ", Sort, Order.ToString());
            }
            else
            {
                return _sqlString = String.Format(" ORDER BY (SELECT NULL) {0} ", Order.ToString());
            }
        }
        public string InitializeSql(Type[] types)
        {
            if (Sort == null)
                return _sqlString = String.Format(" ORDER BY (SELECT NULL) {0} ", Order.ToString());

            var names = new List<string>();
            string tableName = "";

            foreach(var tableType in types)
            {
                string tableNameAux = tableType.Name.ToLower().Substring(1);

                if (Sort.StartsWith(tableNameAux))
                {
                    tableName = tableNameAux;
                    Sort = (tableName + '.' + Sort.Substring(tableName.Length)).ToLower();

                    var colNames = from name in tableType.GetProperties() select name.Name.ToLower();
                    foreach (var col in colNames)
                    {
                        names.Add((tableName + '.' + col).ToLower());
                    }
                    break;
                }
            }

            if (names.Contains(Sort.ToLower()))
            {
                return _sqlString = String.Format(" ORDER BY {0} {1} ", Sort, Order.ToString());
            }
            else
            {
                return _sqlString = String.Format(" ORDER BY (SELECT NULL) {0} ", Order.ToString());
            }
        }
        public string GetSql()
        {
            if (_sqlString == null)
            {
                throw new AccessViolationException("SqlString has not been initialized.");
            }
            else return _sqlString;
        }

        public Sorter(string sortBy, OrderType order = OrderType.ASC)
        {
            Sort = sortBy;
            Order = order;
        }

        public Sorter()
        {
            Sort = null;
            Order = OrderType.ASC;
        }

        public Sorter(Dictionary<string, string> inDict) : this()
        {
            string value;
            if (inDict.TryGetValue("sort", out value))
            {
                Sort = value;
            }

            if (inDict.TryGetValue("order", out value))
            {
                try
                {
                    Order = (OrderType)Enum.Parse(typeof(OrderType), value);
                }
                catch (Exception)
                {
                    Order = OrderType.ASC;
                }
            }
        }
    }
}
