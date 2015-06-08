using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedcLister
{
    public class SqlParameterTemplate
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public bool Required { get; set; }
    }
}
