using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedcLister
{
    static class SqlStrings
    {
        public static SqlStatement UpdateStudent
        {
            get
            {
                return new SqlStatement
                    {
                        Query = @"update Students set DateOfBirth = @dob where FirstName = @firstName and LastName = @lastName",
                        ParameterCount = 3,
                        Parameters = new List<SqlParameterTemplate>
                        {
                            new SqlParameterTemplate
                            {
                                Name = "firstName",
                                Type = typeof (string),
                                Required = true,
                            },
                            new SqlParameterTemplate
                            {
                                Name = "lastName",
                                Type = typeof (string),
                                Required = true,
                            },
                            new SqlParameterTemplate
                            {
                                Name = "dob",
                                Type = typeof (DateTime),
                                Required = true,
                            },

                        }
                    };
            }


        }

        public static void SetParameters(this SqlCommand command, SqlStatement statement, params object[] parameterValues)
        {
            if (statement.ParameterCount != parameterValues.Length)
                throw new Exception();

            int index = 0;
            foreach (var parameterTemplate in statement.Parameters)
            {
                var value = parameterValues[index];
                command.Parameters.AddWithValue("@" + parameterTemplate.Name, value);
                index++;
            }
        }
    }
}
