namespace SensorReportGenerator.Valid
{
    public interface IFilesystem
    {
        void WriteContentToFile(string file, string content);
    }
}
