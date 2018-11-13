using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entities;
using Business;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public ObservableCollection<IPersistable> OrderList { get; set; }
        DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CykelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        ObservableCollection<IPersistable> Rentees;
        ObservableCollection<IPersistable> Bikes;
        public Orders(ObservableCollection<IPersistable> rentees, ObservableCollection<IPersistable> bikes)
        {
            Rentees = rentees;
            Bikes = bikes;
            OrderList = new ObservableCollection<IPersistable>(dc.GetEntities("order"));
            InitializeComponent();
            DataContext = this;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder window = new CreateOrder(Rentees, Bikes);

            if (window.ShowDialog() == true)
            {
                FillOrderList();
                lbxOrders.Items.Refresh();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbxOrders.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an order before you can edit it", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                EditOrder window = new EditOrder(lbxOrders.SelectedItem as Order, Rentees, Bikes);

                if (window.ShowDialog() == true)
                {
                    FillOrderList();
                    lbxOrders.Items.Refresh();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbxOrders.SelectedIndex != -1)
            {
                var message = MessageBox.Show("Are you sure you want to delete this order?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (message == MessageBoxResult.Yes)
                {
                    if (dc.DeleteEntity(lbxOrders.SelectedItem as Order))
                    {
                        MessageBox.Show("The order was deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        FillOrderList();
                        lbxOrders.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("There was an error deleting this order", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select an order before you can delete it", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void FillOrderList()
        {
            OrderList.Clear();
            foreach (var order in dc.GetEntities("order"))
            {
                OrderList.Add(order);
            }
        }
    }
}
