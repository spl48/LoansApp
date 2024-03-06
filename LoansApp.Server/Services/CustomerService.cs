// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using LoansApp.Server;
using LoansApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace LoansApp.Core.Services
{
    public class CustomerService(ApplicationDbContext dbContext) : ICustomerService
    {
        public IEnumerable<Customer> GetAllCustomersData() => dbContext.Customers
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .ToList();
    }
}
