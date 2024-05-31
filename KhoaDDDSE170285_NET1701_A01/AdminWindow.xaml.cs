using BusinessObjects;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DoDuongDangKhoaWPF
{
    public partial class AdminWindow : Window
    {
        public int bookingServationId;
        ICustomerRepo _customerRepo = new CustomerRepo();
        IRoomInfoRepo _roomInfoRepo = new RoomInfoRepo();
        IRoomTypeRepo _roomTypeRepo = new RoomTypeRepo();
        IBookingReservationRepo _bookingReservationRepo = new BookingReservationRepo();
        IBookingDetailsRepo _bookingDetailsRepo = new BookingDetailRepo();

        public AdminWindow()
        {
            InitializeComponent();
            clearCusTextBox();
            loadCustomerData();
            loadRoomData();
            loadReportBookReserData();
        }

        // --------------------------- Customer Management ---------------------------
        private void loadCustomerData()
        {
            List<Customer> customers = _customerRepo.GetAllCustomers();

            CustomerListView.ItemsSource = customers;
        }

        private void clearCusTextBox()
        {
            txtCusId.Text = string.Empty;
            txtCusFullname.Text = string.Empty;
            txtCusEmail.Text = string.Empty;
            txtCusPhone.Text = string.Empty;
            dpCusDOB.SelectedDate = null;
            rbtnActive.IsChecked = true;
            rbtnDelete.IsChecked = false;
            txtSearch.Text = string.Empty;
            rbtnFullname.IsChecked = true;
            rbtnEmail.IsChecked = false;
            rbtnStatus.IsChecked = false;
        }

        private Customer GetCustomerFromSelected()
        {
            try
            {
                string fullName = txtCusFullname.Text;
                string cusEmail = txtCusEmail.Text;
                string cusPhone = txtCusPhone.Text;
                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(cusEmail) || string.IsNullOrWhiteSpace(cusPhone))
                {
                    MessageBox.Show("You must choose one customer.", "Update Customer", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                var customer = _customerRepo.GetCustomerById(int.Parse(txtCusId.Text));
                return customer;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the customer: " + ex.Message, "Update Customer", MessageBoxButton.OK, MessageBoxImage.Error);
                clearCusTextBox();
                return null;
            }
        }

        private void btnCusRefresh_Click(object sender, RoutedEventArgs e)
        {
            clearCusTextBox();
            loadCustomerData();
        }

        private void btnCusCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CusPopUpWPF = new CustomerPopup()
                {
                    isUpdate = false,
                    Owner = this
                };
                CusPopUpWPF.ShowDialog();

                loadCustomerData();
            }
            catch (Exception ex)
            {
                clearCusTextBox();
                MessageBox.Show("An error occurred while creating the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCusEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cus = GetCustomerFromSelected();
                if (cus != null)
                {
                    var CusPopUpWPF = new CustomerPopup(cus);
                    CusPopUpWPF.ShowDialog();
                }


                loadCustomerData();
            }
            catch (Exception ex)
            {
                clearCusTextBox();
                MessageBox.Show("An error occurred while creating the customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCusDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customer = GetCustomerFromSelected();
                if (customer != null)
                {
                    MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete customer id: {customer.CustomerId} with name: {customer.CustomerFullName}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        _customerRepo.DeleteCustomer(customer);
                        loadCustomerData();
                        MessageBox.Show("Customer deleted successfully", "Delete Customer");
                        clearCusTextBox();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Delete Customer");
            }
        }

        private void btnSearchCus_Click(object sender, RoutedEventArgs e)
        {
            List<Customer> customers = new List<Customer>();
            string searchTerm = txtSearch.Text;

            if (rbtnFullname.IsChecked == true)
            {
                customers = _customerRepo.GetCustomerByName(searchTerm);
            }
            else if (rbtnEmail.IsChecked == true)
            {
                customers = _customerRepo.GetCustomerByEmail(searchTerm);
            }
            else if (rbtnStatus.IsChecked == true)
            {
                if (byte.TryParse(searchTerm, out byte status))
                {
                    if (status == 1 || status == 2)
                    {
                        customers = _customerRepo.GetCustomerByStatus(status);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid status (1 for active, 2 for delete).", "Invalid Status", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for status.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            CustomerListView.ItemsSource = customers;
        }

        private void listview_Click(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                var status = ((Customer)item).CustomerStatus;
                if (status != 0)
                {
                    rbtnActive.IsChecked = true;
                }
                else
                {
                    rbtnDelete.IsChecked = true;
                }
                var customer = _customerRepo.GetCustomerById(((Customer)item).CustomerId);
                txtCusId.Text = customer.CustomerId.ToString();
                txtCusFullname.Text = customer.CustomerFullName.ToString();
                txtCusPhone.Text = customer.Telephone.ToString();
                txtCusEmail.Text = customer.EmailAddress.ToString();
                dpCusDOB.Text = customer.CustomerBirthday.ToString();
                if (customer.CustomerStatus == 1)
                {
                    rbtnActive.IsChecked = true; rbtnDelete.IsChecked = false;
                }
                else
                {
                    rbtnActive.IsChecked = false; rbtnDelete.IsChecked = true;
                }
            }
        }

        // --------------------------- Room Management ---------------------------
        private void loadRoomData()
        {
            List<RoomInformation> rooms = _roomInfoRepo.GetAllRoomInformation();

            RoomListView.ItemsSource = rooms;
        }

        private void clearRoomTextBox()
        {
            txtRoomId.Text = string.Empty;
            txtRoomNumber.Text = string.Empty;
            txtRoomDetailDescription.Text = string.Empty;
            txtRoomMaxCapacity.Text = string.Empty;
            txtRoomTypeName.Text = string.Empty;
            txtRoomStatus.Text = string.Empty;
            txtRoomPricePerDay.Text = string.Empty;
            rbtnRoomNumber.IsChecked = true;
            rbtnRoomMaxCapacity.IsChecked = false;
            rbtnRoomPricePerDay.IsChecked = false;
            txtSearchRoom.Text = string.Empty;
        }

        private RoomInformation GetRoomFromSelected()
        {
            try
            {
                string RoomNumber = txtRoomNumber.Text;
                string RoomMaxCapacity = txtRoomMaxCapacity.Text;
                string PricePerDay = txtRoomPricePerDay.Text;
                if (string.IsNullOrWhiteSpace(RoomNumber) || string.IsNullOrWhiteSpace(RoomMaxCapacity) || string.IsNullOrWhiteSpace(PricePerDay))
                {
                    MessageBox.Show("You must choose one room.", "Update Room", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                var room = _roomInfoRepo.GetRoomInformationByRoomId(int.Parse(txtRoomId.Text));
                return room;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the room: " + ex.Message, "Update Room", MessageBoxButton.OK, MessageBoxImage.Error);
                clearRoomTextBox();
                return null;
            }
        }

        private void btnRoomRefress_Click(object sender, RoutedEventArgs e)
        {
            clearRoomTextBox();
            loadRoomData();
        }

        private void btnRoomCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var RoomPopUpWPF = new RoomPopup()
                {
                    isUpdate = false,
                    Owner = this
                };
                RoomPopUpWPF.ShowDialog();

                loadRoomData();
            }
            catch (Exception ex)
            {
                clearRoomTextBox();
                MessageBox.Show("An error occurred while creating the room: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRoomEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var room = GetRoomFromSelected();
                if (room != null)
                {
                    var RoomPopupWPF = new RoomPopup(room);
                    RoomPopupWPF.ShowDialog();
                }

                loadRoomData();
            }
            catch (Exception ex)
            {
                clearRoomTextBox();
                MessageBox.Show("An error occurred while creating the room: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRoomDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var room = GetRoomFromSelected();
                if (room != null)
                {
                    MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete room id: {room.RoomId} with number: {room.RoomNumber}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        _roomInfoRepo.DeleteRoomInformation(room);
                        loadCustomerData();
                        MessageBox.Show("Room deleted successfully", "Delete Room");
                        clearCusTextBox();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Delete Room");
            }
        }

        private void listviewRoom_Click(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                List<RoomType> roomTypes = _roomTypeRepo.GetAllRoomType();
                var roomtypeId = ((RoomInformation)item).RoomTypeId;
                foreach (var roomType in roomTypes)
                {
                    if (roomtypeId == roomType.RoomTypeId)
                    {
                        txtRoomTypeName.Text = roomType.RoomTypeName;
                    }
                }
                var room = _roomInfoRepo.GetRoomInformationByRoomId(((RoomInformation)item).RoomId);
                txtRoomId.Text = room.RoomId.ToString();
                txtRoomNumber.Text = room.RoomNumber.ToString();
                txtRoomDetailDescription.Text = room.RoomDetailDescription.ToString();
                txtRoomMaxCapacity.Text = room.RoomMaxCapacity.ToString();
                txtRoomStatus.Text = room.RoomStatus.ToString();
                txtRoomPricePerDay.Text = room.RoomPricePerDay.ToString();
            }
        }

        private void btnSearchRoom_Click(object sender, RoutedEventArgs e)
        {
            List<RoomInformation> rooms = new List<RoomInformation>();
            string searchTerm = txtSearchRoom.Text;

            if (rbtnRoomNumber.IsChecked == true)
            {
                rooms = _roomInfoRepo.GetRoomsByNumber(searchTerm);
            }
            else if (rbtnRoomMaxCapacity.IsChecked == true)
            {
                if (int.TryParse(searchTerm, out int roomMaxCapacity))
                {
                    rooms = _roomInfoRepo.GetRoomsByMaxCapacity(roomMaxCapacity);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for room capacity.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (rbtnRoomPricePerDay.IsChecked == true)
            {
                if (decimal.TryParse(searchTerm, out decimal roomPricePerDay))
                {
                    rooms = _roomInfoRepo.GetRoomsByPricePerDay(roomPricePerDay);
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for room price per day.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            RoomListView.ItemsSource = rooms;
        }

        // --------------------------- Report Management ---------------------------
        private void loadReportBookReserData()
        {
            try
            {
                var bookings = _bookingReservationRepo.GetBookingReservationsWithCustomerName();
                ReportBookReserListView.ItemsSource = bookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Load Data Book Reservation");
            }
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime? startDate = dpStartDate.SelectedDate;
                DateTime? endDate = dpEndDate.SelectedDate;

                if (startDate == null || endDate == null)
                {
                    MessageBox.Show("Please select both a start date and an end date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (startDate > endDate)
                {
                    MessageBox.Show("The start date must be before the end date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var bookingReservations = _bookingReservationRepo.SearchBookingsByDateRange(startDate, endDate);
                ReportBookReserListView.ItemsSource = bookingReservations;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Load Data Book Reservation");
            }
        }

        private void ReportBookReserListView_Click(object sender, MouseButtonEventArgs e)
        {
            string selectedItem = (sender as ListView).SelectedItem.ToString();
            string bookingReservationIdNotCustom = selectedItem.Substring(25, 3);
            string result = "";

            foreach (char c in bookingReservationIdNotCustom)
            {
                if (char.IsDigit(c))
                {
                    result += c;
                }
            }
            int bookReservationId = int.Parse(result);
            var bookings = _bookingDetailsRepo.GetBookingDetailsOfReservation(bookReservationId);
            ReportBookDetailListView.ItemsSource = bookings;
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
                MessageBox.Show("An error occurred while Logout: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
