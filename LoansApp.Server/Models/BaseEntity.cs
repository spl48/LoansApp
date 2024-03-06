namespace LoansApp.Core.Models
{
    public class BaseEntity : IAuditableEntity
    {
        public int Id { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
