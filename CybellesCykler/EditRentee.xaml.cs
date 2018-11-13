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
    /// Interaction logic for EditRentee.xaml
    /// </summary>
    public partial class EditRentee : Window
    {
        DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CykelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        Rentee Rentee { get; }
        public EditRentee(Rentee rentee)
        {
            Rentee = rentee;
            InitializeComponent();

            tbxAddress.Text = rentee.Address;
            tbxName.Text = rentee.Name;
            tbxPhone.Text = rentee.PhoneNumber;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbxName.Text) && tbxName.Text.Length > 3)
            {
                if (!String.IsNullOrWhiteSpace(tbxPhone.Text) && tbxPhone.Text.Length >= 8)
                {
                    if (!String.IsNullOrWhiteSpace(tbxAddress.Text) && tbxAddress.Text.Length > 6)
                    {
                        Rentee updatedRentee = new Rentee(tbxName.Text, tbxAddress.Text, tbxPhone.Text, Rentee.RegisterDate, Rentee.ID);
                        if (dc.UpdateEntity(updatedRentee))
                        {
                            MessageBox.Show("Rentee updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Rentee couldn't be updated", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must type a valid address", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You must type a valid phone number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("You must type a valid name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
