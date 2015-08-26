using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain
{
    public class Alternative
    {
        public int AlternativeId { get; set; }
        public string AlternativeName { get; set; }

        public override string ToString()
        {
            return AlternativeName;
        }
    }
}
