namespace LoansApp.Core.Models
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
