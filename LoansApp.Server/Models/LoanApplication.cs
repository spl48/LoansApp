using LoansApp.Core.Models;

namespace LoansApp.Server.Models
{
    public class LoanApplication : BaseEntity
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }

        public int CustomerId { get; set; }

        public required Customer Customer { get; set; }
    }
}
