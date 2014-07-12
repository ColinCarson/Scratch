using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TrialData
    {
        public long StressNumber { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
    }
}
