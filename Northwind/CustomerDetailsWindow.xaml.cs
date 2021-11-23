using Northwind.Models;
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
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetailsWindow : Window
    {
        public CustomerDetailsWindow()
        {
            InitializeComponent();
        }

        public CustomerDetailsWindow(Customer customer)
        {
            InitializeComponent();

            txtAddress.Text = customer.Address;
            txtCity.Text = customer.City;
            txtCompanyName.Text = customer.CompanyName;
            txtContactName.Text = customer.ContactName;
            txtCountry.Text = customer.Country;
            txtCustomerId.Text = customer.CustomerId;
        }
    }
}
