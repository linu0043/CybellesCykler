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
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        public ObservableCollection<IPersistable> Rentees { get; }
        public ObservableCollection<IPersistable> Bikes { get; }
        DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CykelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Rentee SelectedRentee { get; set; }
        public Bike SelectedBike { get; set; }


        public CreateOrder(ObservableCollection<IPersistable> rentees, ObservableCollection<IPersistable> bikes)
        {
            Rentees = rentees;
            Bikes = bikes;
            InitializeComponent();
            DataContext = this;
        }

        private void btnSelectRentee_Click(object sender, RoutedEventArgs e)
        {
            if (dtgRentees.SelectedIndex != -1)
            {
                SelectedRentee = dtgRentees.SelectedItem as Rentee;
                tblSelectedRentee.Text = SelectedRentee.ToString();
            }
            else
            {
                MessageBox.Show("You must select a rentee first", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnSelectBike_Click(object sender, RoutedEventArgs e)
        {
            if (dtgBikes.SelectedIndex != -1)
            {
                SelectedBike = dtgBikes.SelectedItem as Bike;
                tblSelectedBike.Text = SelectedBike.ToString();
            }
            else
            {
                MessageBox.Show("You must select a bike first", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRentee != null)
            {
                if (SelectedBike != null)
                {
                    if (dpDelivery != null && dpDelivery.SelectedDate > DateTime.Now)
                    {
                        if (dc.NewEntity(new Order(dtgBikes.SelectedItem as Bike, dtgRentees.SelectedItem as Rentee, DateTime.Now, (DateTime)dpDelivery.SelectedDate, 1)) == true)
                        {
                            MessageBox.Show("Order created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Order couldn't be created", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must select a valid date", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("You must select a bike first", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("You must select a rentee first", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
