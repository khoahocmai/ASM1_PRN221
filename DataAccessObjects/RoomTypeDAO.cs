using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance = null;
        private static object lockObject = new object();
        private FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

        private RoomTypeDAO() { }

        public static RoomTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomTypeDAO();
                }
                return instance;
            }
        }

        //lấy thông tin all phòng
        public List<RoomType> GetAllRoomType()
        {
            return db.RoomTypes.ToList();
        }

        public RoomType? GetRoomTypeByRoomTypeId(int roomTypeId)
        {
            return db.RoomTypes.SingleOrDefault(m => m.RoomTypeId == roomTypeId);
        }

        //thêm RoomType
        public void SaveRoomType(RoomType rt)
        {
            db.RoomTypes.Add(rt);
            db.SaveChanges();
        }

        //Cập nhật thông tin RoomType
        public void UpdateRoomType(RoomType rt)
        {
            db.RoomTypes.Update(rt);
            db.SaveChanges();
        }

        //xóa RoomType
        public void DeleteRoomType(RoomType rt)
        {
            var foundedRoom = db.RoomTypes.SingleOrDefault(m => m.RoomTypeId == rt.RoomTypeId);
            db.RoomTypes.Remove(foundedRoom);
            db.SaveChanges();
        }

        public RoomType GetRoomTypeByRoomTypeName(string roomTypeName)
        {
            var tmp = db.RoomTypes.SingleOrDefault(r => r.RoomTypeName == roomTypeName);
            return tmp;        }
    }
}
