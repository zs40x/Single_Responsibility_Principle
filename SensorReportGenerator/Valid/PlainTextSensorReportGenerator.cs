using System;
using System.IO;

namespace SensorReportGenerator.Valid
{
    public class PlainTextSensorReportGenerator : ISensorReportContentGenerator
    {
        private readonly Sensor _sensor;

        public PlainTextSensorReportGenerator(Sensor sensor)
        {
            _sensor = sensor;
        }

        public string GetContent()
            => ToFileContent();

        private string ToFileContent()
        {
            var fileContent =
                $"#SensorInfo#Name:{_sensor.Name};Average:{_sensor.AverageValue};"
                + $"Minimum:{_sensor.MinimumValue};Maximum:{_sensor.MaximumValue}";

            _sensor.MeasuredValues.ForEach(
                value => fileContent += $@"{Environment.NewLine}##{value}"
                );

            return fileContent;
        }
    }
}
