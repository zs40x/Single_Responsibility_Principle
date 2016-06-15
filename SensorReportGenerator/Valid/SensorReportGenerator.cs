namespace SensorReportGenerator.Valid
{
    public class SensorReportGenerator
    {
        private readonly IFilesystem _filesystem;
        private readonly ISensorReportContentGenerator _sensorReportContentGenerator;

        public SensorReportGenerator(IFilesystem fileSystem, ISensorReportContentGenerator sensorReportContentGenerator)
        {
            _filesystem = fileSystem;
            _sensorReportContentGenerator = sensorReportContentGenerator;
        }

        public void GenerateAndStoreReport(string file)
        {
            _filesystem.WriteContentToFile(file, _sensorReportContentGenerator.GetContent());
        }
    }
}
