using System;
using System.Collections.Generic;
using SensorReportGenerator.Violation;

namespace SensorReportGenerator
{
    class Application
    {
        static void Main(string[] args)
        {
            var sensor = new Sensor("TempSensor 1", new List<double>() { 12.12D, 34.22D, 44.32D, 12.34D });

            sensor.SaveToReportFile("Report.txt");

            Console.ReadKey();
        }
    }
}
