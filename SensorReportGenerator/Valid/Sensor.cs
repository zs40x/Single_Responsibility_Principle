using System.Collections.Generic;
using System.Linq;

namespace SensorReportGenerator.Valid
{
    public class Sensor
    {
        public string Name { get; }
        public List<double> MeasuredValues { get; }
        public double AverageValue
           => MeasuredValues.Average();
        public double MinimumValue
            => MeasuredValues.Min();
        public double MaximumValue
            => MeasuredValues.Max();

        public Sensor(string name, IEnumerable<double> measuredValues)
        {
            Name = name;
            MeasuredValues = new List<double>(measuredValues);
        }
    }
}
