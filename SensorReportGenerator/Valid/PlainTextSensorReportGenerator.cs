using System;
using System.IO;

namespace SensorReportGenerator.Valid
{
    public class PlainTextSensorReportGenerator : ISensorReportGenerator
    {
        private readonly IFilesystem _filesystem;

        public PlainTextSensorReportGenerator(IFilesystem filesystem)
        {
            _filesystem = filesystem;
        }

        public void GenerateReport(Sensor sensor, string reportFile)
        {
            _filesystem.WriteContentToFile(reportFile, ToFileContent(sensor));
        }

        private string ToFileContent(Sensor sensor)
        {
            var fileContent =
                $"#SensorInfo#Name:{sensor.Name};Average:{sensor.AverageValue};"
                + $"Minimum:{sensor.MinimumValue};Maximum:{sensor.MaximumValue}";

            sensor.MeasuredValues.ForEach(
                value => fileContent += $@"{Environment.NewLine}##{value}"
                );

            return fileContent;
        }
    }
}
