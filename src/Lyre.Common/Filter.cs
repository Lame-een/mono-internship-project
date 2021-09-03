using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;

namespace Lyre.Common
{
    public class Filter
    {
        private List<string> _generalQueries = new List<string>();
        private Dictionary<string, string> _columnQueries = new Dictionary<string, string>();
        private Dictionary<string, string> _parameters = new Dictionary<string, string>();
        private int _paramCount = 0;

        private string _sqlString = null;
        private void InitData(string inQuery)
        {
            //queries are either format 'param' or 'column:param'
            string[] splitQuery = inQuery.ToLower().Split(' ');

            foreach (string el in splitQuery)
            {
                string[] kvPair = el.Split(':');
                if (kvPair.Length == 1)
                {
                    if (kvPair[0].Length != 0)
                    {
                        _generalQueries.Add(kvPair[0]);
                    }
                }
                else
                {
                    _columnQueries.Add(kvPair[0], kvPair[1]);
                }
            }
        }

        private string NewParam(string value)
        {
            string ret = "@param" + _paramCount++.ToString();
            _parameters.Add(ret, value);
            return ret;
        }

        private string GetColumnName(PropertyInfo property, string prefix = "")
        {
            StringBuilder stringBuilder = new StringBuilder(prefix, 16);

            if (property.PropertyType == typeof(int))    //if the property is an int, cast the column as int
            {
                stringBuilder.Append(" CAST(");
                stringBuilder.Append(prefix);
                stringBuilder.Append(property.Name.ToLower());
                stringBuilder.Append(" AS VARCHAR(32))");
            }
            else
            {
                stringBuilder.Append(prefix);
                stringBuilder.Append(property.Name.ToLower());
            }

            return stringBuilder.ToString();
        }

        public string InitializeSql(Type type)
        {
            //no filter
            if (_generalQueries.Count == 0 && _columnQueries.Count == 0)
            {
                return _sqlString = "";
            }

            StringBuilder stringBuilder = new StringBuilder("WHERE ", 32);

            List<PropertyInfo> typeProperties = type.GetProperties().ToList();

            bool firstPassed = false;

            foreach (string queryParam in _generalQueries)
            {
                string param = NewParam(queryParam);

                foreach (var property in typeProperties)
                {
                    if ((property.PropertyType == typeof(Guid)) || (Nullable.GetUnderlyingType(property.PropertyType) == typeof(Guid))) //do not filter by IDs
                        continue;

                    if (!firstPassed)
                        firstPassed = true;
                    else
                        stringBuilder.Append(" OR ");

                    stringBuilder.Append(GetColumnName(property));

                    stringBuilder.Append(" LIKE ");
                    stringBuilder.Append(param);
                    //stringBuilder.Append(" ");
                }
            }


            foreach (var colValPair in _columnQueries)
            {
                PropertyInfo property = typeProperties.Find(x => (x.Name.ToLower() == colValPair.Key));
                if (property == null) continue;

                if ((property.PropertyType == typeof(Guid)) || (Nullable.GetUnderlyingType(property.PropertyType) == typeof(Guid)))  //do not filter by IDs
                    continue;

                if (!firstPassed)
                {
                    firstPassed = true;
                }
                else
                {
                    stringBuilder.Append(" OR ");
                }

                stringBuilder.Append(GetColumnName(property));

                stringBuilder.Append(" LIKE ");
                stringBuilder.Append(NewParam(colValPair.Value));
            }

            //check if the data initialization ended up being empty
            if(stringBuilder.ToString() == "WHERE ")
            {
                return _sqlString = "";
            }

            return _sqlString = stringBuilder.ToString();
        }

        
        public string GetSql()
        {
            if (_sqlString == null)
            {
                throw new AccessViolationException("SqlString has not been initialized.");
            }
            else return _sqlString;
        }
        public void AddParameters(SqlCommand command)
        {
            foreach (var kvPair in _parameters)
            {
                command.Parameters.AddWithValue(kvPair.Key, '%' + kvPair.Value + '%');
            }
        }

        public Filter(string inQuery)
        {
            InitData(inQuery);
        }

        public Filter(Dictionary<string, string> inDict)
        {
            string value;
            if (inDict.TryGetValue("filter", out value))
            {
                InitData(value);
            }
            else if (inDict.TryGetValue("q", out value))
            {
                InitData(value);
            }
            else
            {
                InitData("");
            }
        }
    }
}
