using LoansApp.Server.Models;

namespace LoansApp.Core.Services
{
    public interface ILoanApplicationService
    {
        IEnumerable<LoanApplication> GetLoanApplicationsByCustomerId(int customerId);

        Task<bool> CreateLoanApplicationAsync(LoanApplication loanApplication);
    }
}
