namespace TicketManagement.Domain.Common
{
    /// <summary>
    /// Base entity for all the other entities
    /// </summary>
    public class AuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
