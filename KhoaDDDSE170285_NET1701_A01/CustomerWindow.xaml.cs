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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public Customer cusd = new Customer();
        public ICustomerRepo _customerRepo = new CustomerRepo();
        public IBookingReservationRepo _bookingReservationRepo = new BookingReservationRepo(); 
        public CustomerWindow()
        {
            InitializeComponent();  
        }
        public CustomerWindow(Customer customer) : this()
        {
            cusd = customer;
            loadData(customer);
            loadDataListView();
        }

        private void loadData(Customer customer)
        {
            txtCusFullname.Text = customer.CustomerFullName;
            txtCusEmail.Text = customer.EmailAddress;
            txtCusPhone.Text = customer.Telephone;
            dpCusDOB.SelectedDate = customer.CustomerBirthday;
            foreach (char c in customer.Password)
            {
                pbPassword.Password += c;
            }
        }

        private void btnUpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cus = _customerRepo.GetCustomerById(cusd.CustomerId);
                if (cus != null)
                {
                    var CusEditWindow = new CustomerEditWindow(cus);
                    CusEditWindow.ShowDialog();
                }
                loadData(cus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while update information: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                LoginWindow w = new LoginWindow();
                w.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while logout: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void loadDataListView()
        {
            List<BookingReservation> bookingReservations = _bookingReservationRepo.GetBookingReservationsByCusID(cusd.CustomerId);
            bookingListView.ItemsSource = bookingReservations;
        }
    }
}
