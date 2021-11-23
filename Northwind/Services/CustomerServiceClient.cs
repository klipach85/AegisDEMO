using Newtonsoft.Json;
using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace Northwind.Services
{
    public class CustomerServiceClient : ICustomerServiceClient
    {
        private readonly HttpClient _httpClient;

        public CustomerServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Customer AddCustomer(Customer customer)
        {
            var url = $"api/Customer";
            var customerJson = JsonConvert.SerializeObject(customer);

            var stringContent = new StringContent(customerJson, Encoding.UTF8, "application/json");
            var httpResponse = _httpClient.PostAsync(url, stringContent).Result;

            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Customer>(content);

            return result;
        }

        public Customer GetCustomer(string customerId)
        {
            var url = $"api/Customer/{customerId}";

            var httpResponse = _httpClient.GetAsync(url).Result;

            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var customer = JsonConvert.DeserializeObject<Customer>(content);

            return customer;
        }

        public ObservableCollection<Customer> GetCustomers()
        {
            var url = "api/Customer/all";

            var httpResponse = _httpClient.GetAsync(url).Result;

            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var customers = JsonConvert.DeserializeObject<ObservableCollection<Customer>>(content);

            return customers;
        }

        public void RemoveCustomer(string customerId)
        {
            var url = $"api/Customer/{customerId}";

            var httpResponse = _httpClient.DeleteAsync(url).Result;

            if (!httpResponse.IsSuccessStatusCode)
                throw new Exception(httpResponse.ReasonPhrase);
        }
    }
}
