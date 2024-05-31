using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingReservationRepo
    {
        public List<BookingReservation> GetBookingReservationsByCusID(int cusId);

        public List<BookingReservation> GetAllBookingReservation();

        public BookingReservation GetBookingReservation(int bookingId);

        public void SaveBookingReservation(BookingReservation br);

        public void UpdateBookingReservation(BookingReservation br);

        public void DeleteBookingReservation(BookingReservation br);

        public IEnumerable<object> GetBookingReservationsWithCustomerName();

        public List<object> SearchBookingsByDateRange(DateTime? startDate, DateTime? endDate);
    }
}
