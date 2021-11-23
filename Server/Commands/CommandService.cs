using Server.Models;
using System.Collections.Generic;
using System.Linq;

namespace Server.Commands
{
    public class CommandService : ICommandService
    {
        private readonly NorthwindContext _dbContext;

        public CommandService(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCustomer(Customers customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public Customers GetCustomer(string customerId)
        {
            return _dbContext.Customers.Find(customerId);
        }

        public List<Customers> GetCustomers()
        {
            return _dbContext.Customers.Where(c => !c.Orders.Any()).ToList();
        }

        public void RemoveCustomer(string customerId)
        {
            var customer = GetCustomer(customerId);

            if(customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges(); 
            }
        }
    }
}
