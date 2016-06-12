using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorReportGenerator.Violation
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

        public void SaveToReportFile(string reportFile) 
            => SaveReportToFile(reportFile, ToFileContent());

        private void SaveReportToFile(string reportFile, string fileContent)
        {
            using (var fileStream = new FileStream(reportFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(fileContent);
                }
            }
        }

        private string ToFileContent()
        {
            var fileContent =
                $"#SensorInfo#Name:{Name};Average:{AverageValue};"
                + $"Minimum:{MinimumValue};Maximum:{MaximumValue}";

            MeasuredValues.ForEach(
                value => fileContent += $@"{Environment.NewLine}##{value}"
                );

            return fileContent;
        }
    }
}
