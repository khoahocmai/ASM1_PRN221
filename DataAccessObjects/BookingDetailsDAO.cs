using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingDetailsDAO
    {
        private static BookingDetailsDAO instance = null;
        private static object lockObject = new object();
        private FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

        private BookingDetailsDAO() { }

        public static BookingDetailsDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingDetailsDAO();
                }
                return instance;
            }
        }

        public List<BookingDetail> GetBookingDetailsByBookingId(int bookingId)
        {
            return db.BookingDetails.Where(m => m.BookingReservationId == bookingId).ToList();
        }

        public List<BookingDetail> GetBookingDetailsByRoomId(int roomId)
        {
            return db.BookingDetails.Where(m => m.RoomId == roomId).ToList();
        }

        //thêm BookingDetail
        public void SaveBookingDetail(BookingDetail bd)
        {
            db.BookingDetails.Add(bd);
            db.SaveChanges();
        }

        //Cập nhật thông tin BookingDetail
        public void UpdateBookingDetail(BookingDetail bd)
        {
            db.BookingDetails.Update(bd);
            db.SaveChanges();
        }

        //xóa BookingDetail cần cả bookingId và roomID
        public void DeleteBookingDetailBy2Id(BookingDetail bd)
        {
            var foundedBookingDetail = db.BookingDetails
                .SingleOrDefault(m => (m.BookingReservationId == bd.BookingReservationId) && (m.RoomId == bd.RoomId));
            db.BookingDetails.Remove(foundedBookingDetail);
            db.SaveChanges();
        }

        //xóa ByBookingID
        public void DeleteBookingDetailByBookingId(int bookingId)
        {
            var foundedBookingDetail = db.BookingDetails
                .SingleOrDefault(m => m.BookingReservationId == bookingId);
            db.BookingDetails.Remove(foundedBookingDetail);
            db.SaveChanges();
        }

        //xóa ByRoomID
        public void DeleteBookingDetailByRoomId(int roomId)
        {
            var foundedBookingDetail = db.BookingDetails
                .SingleOrDefault(m => m.RoomId == roomId);
            db.BookingDetails.Remove(foundedBookingDetail);
            db.SaveChanges();
        }

        public IEnumerable<object> GetBookingDetailsOfReservation(int bookingReservationId)
        {
            var query = from bd in db.BookingDetails
                        join r in db.RoomInformations on bd.RoomId equals r.RoomId
                        where bd.BookingReservationId == bookingReservationId
                        select new
                        {
                            bd.BookingReservationId,
                            bd.StartDate,
                            bd.EndDate,
                            bd.ActualPrice,
                            RoomNumber = r.RoomNumber
                        };
            return query.ToList();
        }
    }
}
