namespace Infrastructure.DTO
{
    public class FileLineInfo
    {
        public string FileName { get; set; }
        public string Content { get; set; }

        public FileLineInfo(string fileName, string content)
        {
            FileName = fileName;
            Content = content;
        }

    }
}
