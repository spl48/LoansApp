﻿using LoansApp.Server;
using LoansApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace LoansApp.Core.Services
{
    public class CustomerService(ApplicationDbContext dbContext) : ICustomerService
    {
        public IEnumerable<Customer> GetAllCustomersData() => dbContext.Customers
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .Include(c => c.LoanApplications)
                .ToList();

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            try
            {
                dbContext.Customers.Add(customer);
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
