using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomTypeRepo
    {
        public List<RoomType> GetAllRoomType();

        public RoomType? GetRoomTypeByRoomTypeId(int roomTypeId);

        public RoomType? GetRoomTypeByRoomTypeName(string roomTypeName);

        public void SaveRoomType(RoomType rt);

        public void UpdateRoomType(RoomType rt);

        public void DeleteRoomType(RoomType rt);
    }
}
