using System;
using System.Collections.Generic;
using NUnit.Framework;
using SensorReportGenerator.Valid;
using Telerik.JustMock;
using Telerik.JustMock.Expectations.Abstraction;
using Telerik.JustMock.Helpers;

namespace SensorReportGenerator.Tests
{
    [TestFixture]
    public class Valid
    {
        [Test]
        public void TestReportGeneration()
        {
            var sensorName = "TempSensor 1";
            var sensor = new Sensor(sensorName, new List<double>() { 1.0D });

            var expectedContent =
                $"#SensorInfo#Name:{sensorName};Average:1;Minimum:1;Maximum:1{Environment.NewLine}##1";

            var reportGenerator = new PlainTextSensorReportGenerator(sensor);
            
            Assert.AreEqual(expectedContent, reportGenerator.GetContent());
        }
    }
}
