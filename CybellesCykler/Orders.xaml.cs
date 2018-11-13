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
        public ObservableCollection<IPersistable> OrderList { get; }
        DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CykelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public Orders()
        {
            OrderList = new ObservableCollection<IPersistable>(dc.GetEntities("order"));
            InitializeComponent();
            DataContext = this;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
