using LoansApp.Server.Models;

namespace LoansApp.Core.Services
{
    public class LoanApplicationService(ApplicationDbContext dbContext) : ILoanApplicationService
    {
        public IEnumerable<LoanApplication> GetLoanApplicationsByCustomerId(int customerId) =>
            dbContext.LoanApplications
                .OrderBy(a => a.Id)
                .ToList();

        public async Task<bool> CreateLoanApplicationAsync(LoanApplication loanApplication)
        {
            try
            {
                dbContext.LoanApplications.Add(loanApplication);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
