namespace Core.Audit.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = "Abdalla";
        public string? ModifiedBy { get; set; }
    }
}
