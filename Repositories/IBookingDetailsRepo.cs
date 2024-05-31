using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingDetailsRepo
    {
        public List<BookingDetail> GetBookingDetailsByBookingId(int bookingId);

        public List<BookingDetail> GetBookingDetailsByRoomId(int roomId);

        public void SaveBookingDetail(BookingDetail bd);

        public void UpdateBookingDetail(BookingDetail bd);

        public void DeleteBookingDetailBy2Id(BookingDetail bd);

        public void DeleteBookingDetailByBookingId(int bookingId);

        public void DeleteBookingDetailByRoomId(int roomId);

        public IEnumerable<object> GetBookingDetailsOfReservation(int bookingReservationId);
    }
}
