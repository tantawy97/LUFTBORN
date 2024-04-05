namespace Core.Audit.Interface
{
    public interface ISoftDeletedEntity
    {
        public bool IsDeleted { get; set; }
    }
}
