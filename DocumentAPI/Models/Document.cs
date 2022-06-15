namespace DocumentAPI.Models
{
    public enum Status : byte
    {
        Draft,
        Published
    }

    public class Document
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Data { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifedDate { get; set; }
    }
}