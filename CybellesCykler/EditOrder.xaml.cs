using System;
using System.Collections.Generic;
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
using Business;
using Entities;
using System.Collections.ObjectModel;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        public ObservableCollection<IPersistable> Rentees { get; set; }
        public ObservableCollection<IPersistable> Bikes { get; set; }
        public Order Order { get; }
        DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CykelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public EditOrder(Order order, ObservableCollection<IPersistable> rentees, ObservableCollection<IPersistable> bikes)
        {
            Rentees = rentees;
            Bikes = bikes;
            Order = order;

            InitializeComponent();
            DataContext = this;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Order orderToUpdate = new Order(cmbBikes.SelectedItem as Bike, cmbRentee.SelectedItem as Rentee, DateTime.Now, (DateTime)dpDeliver.SelectedDate, Order.ID);

            if (cmbRentee.SelectedIndex != -1)
            {
                if (cmbBikes.SelectedIndex != -1)
                {
                    if (dpDeliver.SelectedDate != null && dpDeliver.SelectedDate > DateTime.Now)
                    {
                        if (dc.UpdateEntity(orderToUpdate) == true)
                        {
                            MessageBox.Show("Order updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Order couldn't be updated", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must select a delivery date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You must select a bike", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("You must select a rentee", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
