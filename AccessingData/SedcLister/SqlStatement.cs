using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SedcLister
{
    public class SqlStatement
    {
        public string Query { get; set; }
        public int ParameterCount { get; set; }
        public IEnumerable<SqlParameterTemplate> Parameters { get; set; }
    }
}
