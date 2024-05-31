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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DoDuongDangKhoaWPF
{
    /// <summary>
    /// Interaction logic for CustomerPopup.xaml
    /// </summary>
    public partial class CustomerPopup : Window
    {
        ICustomerRepo _customerRepo = new CustomerRepo();
        public bool isUpdate;
        public int cusId;
        public CustomerPopup()
        {
            InitializeComponent();
            this.Title = "Create Customer";
        }

        public CustomerPopup(Customer customer) : this()
        {
            this.Title = "Update Customer";
            cusId = customer.CustomerId;
            txtCusFullname.Text = customer.CustomerFullName;
            txtCusEmail.Text = customer.EmailAddress;
            txtCusPhone.Text = customer.Telephone;
            dpCusDOB.SelectedDate = customer.CustomerBirthday;
            isUpdate = true;
            btnAddUpdate.Content = "Update Customer";
        }

        private Customer GetCustomerFromBox()
        {
            try
            {
                string fullName = txtCusFullname.Text;
                string cusEmail = txtCusEmail.Text;
                string cusPhone = txtCusPhone.Text;
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    MessageBox.Show("Customer Fullname is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                if (string.IsNullOrWhiteSpace(cusEmail))
                {
                    MessageBox.Show("Customer Email is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                if (string.IsNullOrWhiteSpace(cusPhone))
                {
                    MessageBox.Show("Customer Phone is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                var newCustomer = new Customer
                {
                    CustomerFullName = txtCusFullname.Text,
                    Telephone = txtCusPhone.Text,
                    EmailAddress = txtCusEmail.Text,
                    CustomerBirthday = dpCusDOB.SelectedDate ?? DateTime.Now,
                    CustomerStatus = 1,
                    Password = "123"
                };

                return newCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private bool CheckCustomerExists(string email, string phone)
        {
            if (_customerRepo.IsEmailExists(email))
            {
                MessageBox.Show("The email address already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            }

            if (_customerRepo.IsPhoneExists(phone))
            {
                MessageBox.Show("The phone number already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            }

            return false;
        }

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isUpdate)
                {
                    var cus = GetCustomerFromBox();
                    if (cus != null)
                    {
                        if (CheckCustomerExists(cus.EmailAddress, cus.Telephone))
                        {
                            return;
                        }

                        cus.CustomerId = 0;
                        _customerRepo.SaveCustomer(cus);
                        MessageBox.Show("Customer created successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);                     
                    }
                    this.Close();
                }
                else
                {
                    var cus = _customerRepo.GetCustomerById(cusId);
                    if (cus != null)
                    {
                        if(cus.CustomerFullName != txtCusFullname.Text)
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
                        _customerRepo.UpdateCustomer(cus);
                        MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.", "Fail", MessageBoxButton.OK, MessageBoxImage.Warning);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while interacting with the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
