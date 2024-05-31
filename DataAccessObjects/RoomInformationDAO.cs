using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoomInformationDAO
    {
        private static RoomInformationDAO instance = null;
        private static object lockObject = new object();
        private FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

        private RoomInformationDAO() { }

        public static RoomInformationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomInformationDAO();
                }
                return instance;
            }
        }

        //lấy thông tin all phòng
        public List<RoomInformation> GetAllRoomInformation()
        {
            return db.RoomInformations.Include(f => f.RoomType).ToList();
        }

        public RoomInformation? GetRoomInformationByRoomId(int roomId)
        {
            return db.RoomInformations.Include(f => f.RoomType).SingleOrDefault(m => m.RoomId == roomId);
        }

        //thêm RoomInformation
        public void SaveRoomInformation(RoomInformation ri)
        {
            db.RoomInformations.Add(ri);
            db.SaveChanges();
        }

        //Cập nhật thông tin RoomInformation
        public void UpdateRoomInformation(RoomInformation ri)
        {
            db.RoomInformations.Update(ri);
            db.SaveChanges();
        }

        //xóa RoomInformation
        public void DeleteRoomInformation(RoomInformation ri)
        {
            var foundedRoom = db.RoomInformations.SingleOrDefault(m => m.RoomId == ri.RoomId);
            db.RoomInformations.Remove(foundedRoom);
            db.SaveChanges();
        }

        public bool IsRoomNumberExists(string roomNumber)
        {
            var tmp = GetAllRoomInformation().SingleOrDefault(c => c.RoomNumber == roomNumber);
            return tmp != null;
        }

        public List<RoomInformation> GetRoomsByNumber(string searchString)
        {
            var temp = GetAllRoomInformation()
                                    .Where(m => m.RoomNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                                    .ToList();
            return temp;
        }
        public List<RoomInformation> GetRoomsByMaxCapacity(int search)
        {
            var temp = GetAllRoomInformation()
                                    .Where(m => m.RoomMaxCapacity == search)
                                    .ToList();
            return temp;
        }

        public List<RoomInformation> GetRoomsByPricePerDay(decimal search)
        {
            var temp = GetAllRoomInformation()
                                    .Where(m => m.RoomPricePerDay == search)
                                    .ToList();
            return temp;
        }
    }
}
