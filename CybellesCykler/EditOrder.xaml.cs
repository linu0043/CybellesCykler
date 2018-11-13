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

        public EditOrder(Order order, ObservableCollection<IPersistable> rentees, ObservableCollection<IPersistable> bikes)
        {
            Rentees = rentees;
            Bikes = bikes;
            Order = order;

            InitializeComponent();
            DataContext = this;
        }
        
    }
}
