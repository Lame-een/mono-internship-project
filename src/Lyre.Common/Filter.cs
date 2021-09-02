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

        //fills _generalQueries and _columnQueries with data reieved from the queryString
        //non-value queries are placed in _generalQueries
        //'key:value' queries are played in _columnQueries
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

        //constructs a new parameter which is used in 'AddParameters()'
        //
        private string NewParam(string value)
        {
            string ret = "@param" + _paramCount++.ToString();
            _parameters.Add(ret, value);
            return ret;
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

            //adds clauses concerning parameters compared to all columns
            foreach (string queryParam in _generalQueries)
            {
                string param = NewParam(queryParam);

                foreach (var property in typeProperties)
                {
                    if (property.PropertyType == typeof(Guid)) //do not filter by IDs
                        continue;

                    //adds ORs between the clauses
                    if (!firstPassed)
                        firstPassed = true;
                    else
                        stringBuilder.Append(" OR ");

                    if (property.PropertyType == typeof(int))    //if the property is an int, cast the column as int
                    {
                        stringBuilder.Append(" CAST(");
                        stringBuilder.Append(property.Name.ToLower());
                        stringBuilder.Append(" AS VARCHAR(32))");
                    }
                    else
                    {
                        stringBuilder.Append(property.Name.ToLower());
                    }

                    stringBuilder.Append(" LIKE ");
                    stringBuilder.Append(param);
                    //stringBuilder.Append(" ");
                }
            }

            //adds clauses concerning specific column queries
            foreach (var colValPair in _columnQueries)
            {
                PropertyInfo property = typeProperties.Find(x => (x.Name.ToLower() == colValPair.Key));
                if (property == null) continue;

                if (property.PropertyType == typeof(Guid))  //do not filter by IDs
                    continue;

                if (!firstPassed)
                {
                    firstPassed = true;
                }
                else
                {
                    stringBuilder.Append(" OR ");
                }

                if (property.PropertyType == typeof(int))    //if the property is an int, cast the column as int
                {
                    stringBuilder.Append(" CAST(");
                    stringBuilder.Append(property.Name.ToLower());
                    stringBuilder.Append(" AS VARCHAR(32))");
                }
                else
                {
                    stringBuilder.Append(property.Name.ToLower());
                }

                stringBuilder.Append(" LIKE ");
                stringBuilder.Append(NewParam(colValPair.Value));
                //stringBuilder.Append(" ");
            }

            _sqlString = stringBuilder.ToString();

            return _sqlString;
        }

        public string GetSql()
        {
            if (_sqlString == null)
            {
                throw new AccessViolationException("SqlString has not been initialized.");
            }
            else return _sqlString;
        }
        public string GetSql(Type type)
        {
            if (_sqlString == null)
            {
                return InitializeSql(type);
            }
            else return _sqlString;
        }
        public void AddParameters(SqlCommand command)
        {
            foreach(var kvPair in _parameters)
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
