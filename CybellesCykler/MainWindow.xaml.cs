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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Entities;
using System.Collections.ObjectModel;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Rentee> RenteeList { get; }
        public ObservableCollection<Bike> BikeList { get; }

        public MainWindow()
        {
            RenteeList = new ObservableCollection<Rentee>();
            BikeList = new ObservableCollection<Bike>();

            InitializeComponent();
            DataContext = this;
        }
        
        private void BtnShowOrders_Click(object sender, RoutedEventArgs e)
        {
            Orders window = new Orders();

            if (window.ShowDialog() == true)
            {

            }
        }

        private void DtgSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
