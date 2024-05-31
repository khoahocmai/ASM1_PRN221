using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        ICustomerRepo customerRepo = new CustomerRepo();

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //admin
            //"Email": "admin@FUMiniHotelSystem.com",
            //"Password": "@@abc123@@"
            //user: id 3
            //"Email": "WilliamShakespeare@FUMiniHotel.org",
            //"Password": "123@"
            IConfiguration configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", true, true)
                            .Build();
            string adminEmail = configuration["AdminAccount:Email"];
            string adminPass = configuration["AdminAccount:Password"];

            string inputEmail = txtEmail.Text;
            string inputPass = pswPassword.Password;

            if (inputEmail == null || inputEmail == "" || inputPass == null || inputPass == "")
            {
                MessageBox.Show("You must enter all fields !", "Login Window");
            }
            else
            {
                if (inputEmail == adminEmail && inputPass == adminPass)
                {
                    this.Hide();
                    AdminWindow w = new AdminWindow();
                    w.ShowDialog();
                    this.Close();
                    return;
                }
                Customer customer = customerRepo.CheckLogin(inputEmail, inputPass);
                if (customer != null)
                {
                    if (customer.CustomerStatus == 1)
                    {
                        this.Hide();
                        CustomerWindow w = new CustomerWindow(customer);
                        w.ShowDialog();
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Your account is banned", "Login Window");
                    }
                }
                else
                {
                    MessageBox.Show("Login failed. Incorrect email or password", "Login Window");
                }
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerEditWindow w = new CustomerEditWindow();
            w.ShowDialog();
            this.Close();
        }
    }
}
