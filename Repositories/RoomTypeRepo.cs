using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects;

namespace Repositories
{
    public class RoomTypeRepo : IRoomTypeRepo
    {
        public List<RoomType> GetAllRoomType()
            => RoomTypeDAO.Instance.GetAllRoomType();

        public RoomType? GetRoomTypeByRoomTypeId(int roomTypeId)
            => RoomTypeDAO.Instance.GetRoomTypeByRoomTypeId(roomTypeId);

        public void SaveRoomType(RoomType rt)
            => RoomTypeDAO.Instance.SaveRoomType(rt);

        public void UpdateRoomType(RoomType rt)
            => RoomTypeDAO.Instance.UpdateRoomType(rt);

        public void DeleteRoomType(RoomType rt)
            => RoomTypeDAO.Instance.DeleteRoomType(rt);

        public RoomType? GetRoomTypeByRoomTypeName(string roomTypeName)
            => RoomTypeDAO.Instance.GetRoomTypeByRoomTypeName(roomTypeName);
    }
}
