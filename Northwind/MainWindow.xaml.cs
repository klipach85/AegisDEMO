using Northwind.Models;
using Northwind.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Northwind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerServiceClient _customerServiceClient;

        public static ObservableCollection<Customer> ListOfCustomers { get; set; }
        public int SelectedIndex { get; set; } = -1;

        public MainWindow(ICustomerServiceClient customerServiceClient)
        {
            InitializeComponent();

            _customerServiceClient = customerServiceClient;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ListOfCustomers = _customerServiceClient.GetCustomers();
            lstCustomers.ItemsSource = ListOfCustomers;
        }

        private void lstCustomers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView list = (ListView)sender;
            SelectedIndex = list.SelectedIndex;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer");
            }
            else
            {
                _customerServiceClient.RemoveCustomer(ListOfCustomers[SelectedIndex].CustomerId);

                ListOfCustomers.RemoveAt(SelectedIndex);

                MessageBox.Show("Success");

                SelectedIndex = -1;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new NewCustomerWindow(_customerServiceClient);
            addWindow.Show();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedIndex == -1)
            {
                MessageBox.Show("Please select a customer");
            }
            else
            {
                var customerDetailsWindow = new CustomerDetailsWindow(ListOfCustomers[SelectedIndex]);

                customerDetailsWindow.Show();
            }
        }
    }
}
