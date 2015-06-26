using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperExample
{
    static class DapperMappings
    {
        public static void Init()
        {
            MapStudent();
        }

        private static void MapStudent()
        {
            SqlMapper.SetTypeMap(typeof(Student),
                new CustomPropertyTypeMap(typeof(Student),
                    (type, columnName) =>
                    {
                        if (columnName == "PhoneNumber")
                        {
                            return type.GetProperty("Phone");
                        }
                        return type.GetProperty(columnName);
                    }));
        }


        public static DynamicParameters MapParameters(Dictionary<string, object> parameters)
        {
            var dynparameters = new DynamicParameters();
            foreach (var parameter in parameters)
            {
                dynparameters.Add(parameter.Key, parameter.Value);
            }
            return dynparameters;
        }




    }
}
