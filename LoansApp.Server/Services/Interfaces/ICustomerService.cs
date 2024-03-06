using LoansApp.Server;

namespace LoansApp.Core.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomersData();

        Task<bool> CreateCustomerAsync(Customer customer);
    }
}
