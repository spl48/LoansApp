using LoansApp.Core.Models;

namespace LoansApp.Server.Models
{
    public class LoanApplication : BaseEntity
    {
        public decimal Amount { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }

        public int CustomerId { get; set; }

        public required Customer Customer { get; set; }
    }
}
