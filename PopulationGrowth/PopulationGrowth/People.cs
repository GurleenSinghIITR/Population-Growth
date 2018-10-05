using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationGrowth
{
    class People
    {
        public decimal Value { get; set; }

        
        public string Message { get; set; }

        
        public override string ToString()
        {
            return Message + Value + "\n";
        }
    }
}
