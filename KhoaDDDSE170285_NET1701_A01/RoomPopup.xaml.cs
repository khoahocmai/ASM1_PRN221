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
    /// Interaction logic for RoomPopup.xaml
    /// </summary>
    public partial class RoomPopup : Window
    {
        IRoomInfoRepo _roomInfoRepo = new RoomInfoRepo();
        IRoomTypeRepo _roomTypeRepo = new RoomTypeRepo();
        public bool isUpdate;
        public int roomId;
        public List<RoomType> roomTypes;
        public RoomPopup()
        {
            InitializeComponent();
            this.Title = "Create Room";
            roomTypes = _roomTypeRepo.GetAllRoomType();
            cbbRoomTypeName.ItemsSource = roomTypes;
            cbbRoomTypeName.DisplayMemberPath = "RoomTypeName";
        }

        public RoomPopup(RoomInformation roomInfo) : this()
        {
            this.Title = "Update Room";
            roomTypes = _roomTypeRepo.GetAllRoomType();
            cbbRoomTypeName.ItemsSource = roomTypes;
            cbbRoomTypeName.DisplayMemberPath = "RoomTypeName";

            roomId = roomInfo.RoomId;

            txtRoomId.Text = roomId.ToString();
            txtRoomNumber.Text = roomInfo.RoomNumber;
            txtRoomDetailDescription.Text = roomInfo.RoomDetailDescription;
            txtRoomMaxCapacity.Text = roomInfo.RoomMaxCapacity.ToString();
            txtRoomPricePerDay.Text = roomInfo.RoomPricePerDay.ToString();
            txtRoomStatus.Text = roomInfo.RoomStatus.ToString();

            //var roomType = _roomTypeRepo.GetRoomTypeByRoomTypeId(roomInfo.RoomTypeId);
            //if (roomType != null)
            //{
            //    cbbRoomTypeName.DisplayMemberPath = roomType.RoomTypeName;
            //}

            isUpdate = true;
            btnAddUpdate.Content = "Update Room";
        }

        private RoomInformation GetRoomFromBox()
        {
            try
            {
                string RoomNumber = txtRoomNumber.Text;
                string RoomMaxCapacity = txtRoomMaxCapacity.Text;
                string RoomPricePerDay = txtRoomPricePerDay.Text;
                string RoomTypeName = cbbRoomTypeName.Text;
                string RoomStatus = txtRoomStatus.Text;
                if (string.IsNullOrWhiteSpace(RoomNumber))
                {
                    MessageBox.Show("Room Number is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                if (string.IsNullOrWhiteSpace(RoomMaxCapacity))
                {
                    MessageBox.Show("Room Max Capacity is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                if (string.IsNullOrWhiteSpace(RoomPricePerDay))
                {
                    MessageBox.Show("Room Price Per Day is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                if (string.IsNullOrWhiteSpace(RoomTypeName))
                {
                    MessageBox.Show("Room Type Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                if (string.IsNullOrWhiteSpace(RoomStatus))
                {
                    MessageBox.Show("Room Status is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
                roomTypes = _roomTypeRepo.GetAllRoomType();
                var roomTypeId = 1;
                foreach (var item in roomTypes)
                {
                    if (cbbRoomTypeName.Text == item.RoomTypeName)
                    {
                        roomTypeId = item.RoomTypeId;
                    }
                }

                var newRoom = new RoomInformation
                {
                    RoomNumber = txtRoomNumber.Text,
                    RoomDetailDescription = txtRoomDetailDescription.Text,
                    RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text),
                    RoomTypeId = roomTypeId,
                    RoomStatus = byte.Parse(txtRoomStatus.Text),
                    RoomPricePerDay = decimal.Parse(txtRoomPricePerDay.Text),
                };

                return newRoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the room: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isUpdate)
                {
                    var room = GetRoomFromBox();
                    if (room != null)
                    {
                        if (CheckRoomExists(room.RoomNumber))
                        {
                            return;
                        }

                        room.RoomId = 0;
                        _roomInfoRepo.SaveRoomInformation(room);
                        MessageBox.Show("Room created successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    this.Close();
                }
                else
                {
                    var room = _roomInfoRepo.GetRoomInformationByRoomId(roomId);
                    if (room != null)
                    {
                        if (room.RoomNumber != txtRoomNumber.Text)
                        {
                            if (_roomInfoRepo.IsRoomNumberExists(room.RoomNumber))
                            {
                                MessageBox.Show("The Room Number already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                            room.RoomNumber = txtRoomNumber.Text;
                        }
                        if (room.RoomDetailDescription != txtRoomDetailDescription.Text)
                        {
                            room.RoomDetailDescription = txtRoomDetailDescription.Text;
                        }
                        if (room.RoomMaxCapacity != int.Parse(txtRoomMaxCapacity.Text))
                        {
                            room.RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text);
                        }

                        var roomType = _roomTypeRepo.GetRoomTypeByRoomTypeName(cbbRoomTypeName.Text);

                        if (room.RoomTypeId != roomType.RoomTypeId)
                        {
                            room.RoomTypeId = roomType.RoomTypeId;
                        }

                        if (room.RoomStatus != byte.Parse(txtRoomStatus.Text))
                        {
                            room.RoomStatus = byte.Parse(txtRoomStatus.Text);
                        }
                        if (room.RoomPricePerDay != decimal.Parse(txtRoomPricePerDay.Text))
                        {
                            room.RoomPricePerDay = decimal.Parse(txtRoomPricePerDay.Text);
                        }

                        _roomInfoRepo.UpdateRoomInformation(room);
                        MessageBox.Show("Room updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Room not found.", "Fail", MessageBoxButton.OK, MessageBoxImage.Warning);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while interacting with the room: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CheckRoomExists(string roomNumber)
        {
            if (_roomInfoRepo.IsRoomNumberExists(roomNumber))
            {
                MessageBox.Show("The roomNumber already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            }

            return false;
        }
    }
}
