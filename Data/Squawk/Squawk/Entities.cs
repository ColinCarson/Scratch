namespace Squawk
{
    using System.Collections.Generic;

    public class Parameter
    {
        public string Name { get; set; }
        public long TrialNumber { get; set; }
        public double Value { get; set; }
    }

    public class TrialData
    {
        public long StressNumber { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }
    }
}