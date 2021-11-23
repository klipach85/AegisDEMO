using Northwind.Models;
using Northwind.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Northwind
{
    /// <summary>
    /// Interaction logic for NewCustomerWindow.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        private readonly ICustomerServiceClient _customerServiceClient;

        public NewCustomerWindow()
        {
            InitializeComponent();
        }

        public NewCustomerWindow(ICustomerServiceClient customerServiceClient)
        {
            InitializeComponent();
            _customerServiceClient = customerServiceClient;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer
            {
                CompanyName = txtCompanyName.Text,
                Address = txtAddress.Text,
                ContactName = txtContactName.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                ContactTitle = txtContactTitle.Text
            };

            var response = _customerServiceClient.AddCustomer(customer);

            this.Close();
            MessageBox.Show("Success");

            MainWindow.ListOfCustomers.Add(response);
        }
    }
}
