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
            var fileName = "FileName.txt";
            var sensor = new Sensor(sensorName, new List<double>() { 1.0D });

            var fileSystemMock = Mock.Create<IFilesystem>();
            var expectedContent =
                $"#SensorInfo#Name:{sensorName};Average:1;Minimum:1;Maximum:1{Environment.NewLine}##1";
            fileSystemMock.Arrange((x) => fileSystemMock.WriteContentToFile(fileName, expectedContent)).MustBeCalled();

            var reportGenerator = new PlainTextSensorReportGenerator(fileSystemMock);
            reportGenerator.GenerateReport(sensor, fileName);

            Mock.Assert(fileSystemMock);
        }
    }
}
