### Built With

* NET CORE 3.1
* MS SQL
* Web API
* WPF

### Prerequisites

Install .NET Core >= 3.1

Execute setup.sql file in MS Sql. You can also find the file [here](https://raw.githubusercontent.com/microsoft/sql-server-samples/master/samples/databases/northwind-pubs/instnwnd.sql)

Change connection string in "Server" project in appSettings.json file

You'll have run both projects (api and wpf) at the same time.
Open the solution in Visual Studio, right click on the Solution -> Properties -> Multiple Startup Projeccts -> Change action to Start on both projects


## Work Items

* On the main window, load a list of customers in a listView component. Display following properties :  Company Name, Contact name, and Contact Title.  Add following buttons next to the listView : Add Customer, Remove Customer View Customer.
* When clicking on "Add Customer" button on main window, open a new window that has textboxes to enter customer info and a "Save" button. By clicking on "Save" button make a http post call to Server API to save customer info, close the window and show a success message, add the new customer to the list on main window.
* When clicking on "Remove Customer", remove the customer from the list if any is selected, otherwise show a warning message to select a customer.
* When clicking on "View Customer" button open a new window that has displays more information for the customer
