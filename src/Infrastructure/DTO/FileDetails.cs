namespace Infrastructure.DTO
{
    public class FileDetails
    {
        public string Name { get; set; }
        public long SizeInBytes { get; set; }
        public DateTime UpdatedAt { get; set; }

        public FileDetails(string name, long size, DateTime updatedAt)
        {
            Name = name;
            SizeInBytes = size;
            UpdatedAt = updatedAt;
        }
    }

}
