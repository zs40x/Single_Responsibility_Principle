namespace SensorReportGenerator.Valid
{
    public interface ISensorReportGenerator
    {
        void GenerateReport(Sensor sensor, string reportFile);
    }
}
