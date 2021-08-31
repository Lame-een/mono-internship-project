using System;
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
        public string SortBy { get; set; }

        ///<summary>
        ///Checks if the <strong>SortBy</strong> property is contained in a column of 
        ///the <strong>type</strong> model class.
        ///</summary>
        ///<example>Example usage:
        ///<code>
        /// Sorter sorter = new Sorter("name");
        /// 
        /// ...
        /// 
        /// string sqlSelect = "SELECT * FROM song" + filter.GetSql() + sorter.GetSql(typeof(ISong)) + pager.GetSql() + ';';
        /// </code>
        ///</example>
        ///<param name="type">Type of the Model object which is being sorted</param>
        ///<returns><strong>string</strong> SQL command snippet</returns>
        public string GetSql(Type type)
        {
            if (SortBy == null)
                return String.Format(" ORDER BY (SELECT NULL) {0} ", Order.ToString());

            var names = (from name in type.GetProperties() select name.Name.ToLower());

            if (names.Contains(SortBy.ToLower()))
            {
                return String.Format(" ORDER BY {0} {1} ", SortBy, Order.ToString());
            }
            else
            {
                return String.Format(" ORDER BY (SELECT NULL) {0} ", Order.ToString());
            }
        }

        public Sorter(string sortBy, OrderType order = OrderType.ASC)
        {
            SortBy = sortBy;
            Order = order;
        }

        public Sorter()
        {
            SortBy = null;
            Order = OrderType.ASC;
        }
    }
}
