using LoansApp.Core.Models;
using LoansApp.Server;

namespace LoansApp.Core.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomersData();
    }
}
