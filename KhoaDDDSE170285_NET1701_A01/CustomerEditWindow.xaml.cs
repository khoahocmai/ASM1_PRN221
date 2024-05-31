using BusinessObjects;
using Repositories;
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

namespace DoDuongDangKhoaWPF
{
    /// <summary>
    /// Interaction logic for CustomerEditWindow.xaml
    /// </summary>
    public partial class CustomerEditWindow : Window
    {
        public Customer customerGlobal;
        public ICustomerRepo _customerRepo = new CustomerRepo();
        public CustomerEditWindow()
        {
            InitializeComponent();
            this.Title = "Register";
        }

        public CustomerEditWindow(Customer customer) : this()
        {
            this.Title = "Update Customer";
            customerGlobal = customer;
            txtCusFullname.Text = customer.CustomerFullName;
            txtCusEmail.Text = customer.EmailAddress;
            txtCusPhone.Text = customer.Telephone;
            dpCusDOB.SelectedDate = customer.CustomerBirthday;
            txtPassword.Text = customer.Password;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Customer cus = customerGlobal;
            if (cus != null)
            {
                if (cus.CustomerFullName != txtCusFullname.Text)
                {
                    cus.CustomerFullName = txtCusFullname.Text;
                }
                if (cus.EmailAddress != txtCusEmail.Text)
                {
                    if (_customerRepo.IsEmailExists(txtCusEmail.Text))
                    {
                        MessageBox.Show("The email address already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    cus.EmailAddress = txtCusEmail.Text;
                }
                if (cus.Telephone != txtCusPhone.Text)
                {
                    if (_customerRepo.IsEmailExists(txtCusPhone.Text))
                    {
                        MessageBox.Show("The phone already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    cus.Telephone = txtCusPhone.Text;
                }
                DateTime? selectedDate = dpCusDOB.SelectedDate;
                if (cus.CustomerBirthday != selectedDate)
                {
                    cus.CustomerBirthday = selectedDate;
                }
                if (cus.Password != txtPassword.Text)
                {
                    cus.Password = txtPassword.Text;
                }
                _customerRepo.UpdateCustomer(cus);
                MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                Customer newCus = new Customer();
                newCus.CustomerFullName = txtCusFullname.Text;
                if (_customerRepo.IsEmailExists(txtCusEmail.Text))
                {
                    MessageBox.Show("The email address already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                newCus.EmailAddress = txtCusEmail.Text;

                if (_customerRepo.IsEmailExists(txtCusPhone.Text))
                {
                    MessageBox.Show("The phone already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                newCus.Telephone = txtCusPhone.Text;
                newCus.CustomerBirthday = dpCusDOB.SelectedDate;
                newCus.CustomerStatus = 1;
                newCus.Password = txtPassword.Text;
                _customerRepo.SaveCustomer(newCus);
                MessageBox.Show("Customer registered successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                LoginWindow w = new LoginWindow();
                w.ShowDialog();
                this.Close();

            }
        }
    }
}
