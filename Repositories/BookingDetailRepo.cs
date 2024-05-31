using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepo : IBookingDetailsRepo
    {
        public List<BookingDetail> GetBookingDetailsByBookingId(int bookingId)
            => BookingDetailsDAO.Instance.GetBookingDetailsByBookingId(bookingId);

        public List<BookingDetail> GetBookingDetailsByRoomId(int roomId)
            => BookingDetailsDAO.Instance.GetBookingDetailsByRoomId(roomId);

        public void SaveBookingDetail(BookingDetail bd)
            => BookingDetailsDAO.Instance.SaveBookingDetail(bd);

        public void UpdateBookingDetail(BookingDetail bd)
            => BookingDetailsDAO.Instance.UpdateBookingDetail(bd);

        public void DeleteBookingDetailBy2Id(BookingDetail bd)
            => BookingDetailsDAO.Instance.DeleteBookingDetailBy2Id(bd);

        public void DeleteBookingDetailByBookingId(int bookingId)
            => BookingDetailsDAO.Instance.DeleteBookingDetailByBookingId(bookingId);

        public void DeleteBookingDetailByRoomId(int roomId)
            => BookingDetailsDAO.Instance.DeleteBookingDetailByRoomId(roomId);

        public IEnumerable<object> GetBookingDetailsOfReservation(int bookingReservationId)
            => BookingDetailsDAO.Instance.GetBookingDetailsOfReservation(bookingReservationId);
    }
}
