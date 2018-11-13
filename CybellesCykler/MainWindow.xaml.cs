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
using Business;
using System.Collections.ObjectModel;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<IPersistable> RenteeList { get; }
        public ObservableCollection<IPersistable> BikeList { get; }
        DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CykelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public MainWindow()
        {
            RenteeList = new ObservableCollection<IPersistable>(dc.GetEntities("rentee"));
            BikeList = new ObservableCollection<IPersistable>(dc.GetEntities("bike"));
            
            InitializeComponent();
            DataContext = this;
        }
        
        private void BtnShowOrders_Click(object sender, RoutedEventArgs e)
        {
            Orders window = new Orders(RenteeList, BikeList);

            if (window.ShowDialog() == true)
            {

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tabSelect.SelectedIndex == 0)
            {
                MessageBox.Show("lol");
            }
            else
            {
                MessageBox.Show("skede");
            }
        }
    }
}
