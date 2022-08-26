namespace Domain.DTO
{
    public class FileDetails
    {

        public string Name { get; set; }
        public int Size { get; set; }
        public DateTime UpdatedAt { get; set; }

        public FileDetails(string name, int size, DateTime updatedAt)
        {
            Name = name;
            Size = size;
            UpdatedAt = updatedAt;
        }
    }

}
