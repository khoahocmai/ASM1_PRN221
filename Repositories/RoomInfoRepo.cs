using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects;

namespace Repositories
{
    public class RoomInfoRepo : IRoomInfoRepo
    {
        public List<RoomInformation> GetAllRoomInformation()
            => RoomInformationDAO.Instance.GetAllRoomInformation();

        public RoomInformation? GetRoomInformationByRoomId(int roomId)
            => RoomInformationDAO.Instance.GetRoomInformationByRoomId(roomId);

        public void SaveRoomInformation(RoomInformation ri)
            => RoomInformationDAO.Instance.SaveRoomInformation(ri);

        public void UpdateRoomInformation(RoomInformation ri)
            => RoomInformationDAO.Instance.UpdateRoomInformation(ri);

        public void DeleteRoomInformation(RoomInformation ri)
            => RoomInformationDAO.Instance.DeleteRoomInformation(ri);

        public bool IsRoomNumberExists(string roomNumber) 
            => RoomInformationDAO.Instance.IsRoomNumberExists(roomNumber);

        public List<RoomInformation> GetRoomsByNumber(string search)
            => RoomInformationDAO.Instance.GetRoomsByNumber(search);

        public List<RoomInformation> GetRoomsByMaxCapacity(int search)
            => RoomInformationDAO.Instance.GetRoomsByMaxCapacity(search);
    
        public List<RoomInformation> GetRoomsByPricePerDay(decimal search)
            => RoomInformationDAO.Instance.GetRoomsByPricePerDay(search);
    }
}
