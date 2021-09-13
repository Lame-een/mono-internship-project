using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lyre.Common
{
    public class Pager
    {
        public int PageSize { get; set; }
        public int Page { get; set; }

        public int Offset { get => (Page - 1) * PageSize; }

        public string GetSql()
        {
            return " OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY ";
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Offset", Offset);
            command.Parameters.AddWithValue("@PageSize", PageSize);
        }

        public Pager(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize < 1)
            {
                pageSize = 10;
            }

            PageSize = pageSize;
            Page = pageNumber;
        }

        public Pager(Dictionary<string, string> inDict) : this()
        {
            string value;
            if (inDict.TryGetValue("page", out value))
            {
                Page = Convert.ToInt32(value);
            }

            if (inDict.TryGetValue("pagesize", out value))
            {
                PageSize = Convert.ToInt32(value);
            }
        }
    }
}
