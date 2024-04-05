namespace Core.Audit.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string UserEmail { get; set; } = "Abdalla@gmail.com";
        public required string EntityName { get; set; }
        public required string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public required string Changes { get; set; }
    }
}
