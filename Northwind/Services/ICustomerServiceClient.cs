using Northwind.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public interface ICustomerServiceClient
    {
        public ObservableCollection<Customer> GetCustomers();
        public Customer GetCustomer(string customerId);
        public void RemoveCustomer(string customerId);
        public Customer AddCustomer(Customer customer);
    }
}
