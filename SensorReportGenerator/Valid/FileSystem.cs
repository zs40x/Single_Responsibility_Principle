using System.IO;

namespace SensorReportGenerator.Valid
{
    class FileSystem : IFilesystem
    {
        public void WriteContentToFile(string file, string content)
        {
            using (var fileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(content);
                }
            }
        }
    }
}
