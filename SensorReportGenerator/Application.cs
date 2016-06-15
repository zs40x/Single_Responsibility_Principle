using System;
using System.Collections.Generic;
using SensorReportGenerator.Valid;

namespace SensorReportGenerator
{
    internal class Application
    {
        private static void Main()
        {
            var sensorViolation = 
                new Violation.Sensor("TempSensor 1", new List<double> { 12.12D, 34.22D, 44.32D, 12.34D });
            sensorViolation.SaveToReportFile("Report_1.txt");
            Console.WriteLine("Exported Report 1...");

            var sensorValid = 
                new Valid.Sensor("TemSensor 2", new List<double> { 12.4D, 77.2D, 88.1D });
            var reportGenerator = 
                new Valid.SensorReportGenerator(
                        new FileSystem(),
                        new PlainTextSensorReportGenerator(sensorValid)
                    );
            reportGenerator.GenerateAndStoreReport("Report_2.txt");
            Console.WriteLine("Exported Report 2");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
