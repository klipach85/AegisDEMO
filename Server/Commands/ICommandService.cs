using Server.Models;
using System.Collections.Generic;

namespace Server.Commands
{
    public interface ICommandService
    {
        public List<Customers> GetCustomers();
        public Customers GetCustomer(string customerId);
        public void RemoveCustomer(string customerId);
        public void AddCustomer(Customers customer);
    }
}
