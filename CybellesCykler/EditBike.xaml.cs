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
using Entities;
using Business;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for EditBike.xaml
    /// </summary>
    public partial class EditBike : Window
    {
        DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CykelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        Bike Bike { get; }
        public EditBike(Bike bike)
        {
            Bike = bike;
            InitializeComponent();

            foreach (var kind in Enum.GetValues(typeof(BikeKind)))
            {
                cmbKinds.Items.Add(kind);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (cmbKinds.SelectedIndex != -1)
            {
                decimal result;
                if (decimal.TryParse(tbxPrice.Text, out result))
                {
                    if (!String.IsNullOrWhiteSpace(tbxDesc.Text))
                    {
                        if (dc.UpdateEntity(new Bike(result, tbxDesc.Text, (BikeKind)cmbKinds.SelectedItem, Bike.ID)))
                        {
                            MessageBox.Show("Bike updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Bike couldn't be updated", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must type a bike description", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You must write a valid price", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("You must select a bike kind", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
