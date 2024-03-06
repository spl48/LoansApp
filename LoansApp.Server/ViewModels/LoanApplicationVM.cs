using LoansApp.Server.Models;

namespace LoansApp.Server.ViewModels
{
    public class LoanApplicationVM
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}
