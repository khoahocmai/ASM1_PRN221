using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects;

namespace Repositories
{
    public class BookingReservationRepo : IBookingReservationRepo
    {
        public List<BookingReservation> GetBookingReservationsByCusID(int cusId)
            => BookingReservationDAO.Instance.GetBookingReservationsByCusID(cusId);

        public List<BookingReservation> GetAllBookingReservation()
            => BookingReservationDAO.Instance.GetAllBookingReservation();

        public BookingReservation GetBookingReservation(int bookingId)
            => BookingReservationDAO.Instance.GetBookingReservation(bookingId);

        public void SaveBookingReservation(BookingReservation br)
            => BookingReservationDAO.Instance.SaveBookingReservation(br);

        public void UpdateBookingReservation(BookingReservation br)
            => BookingReservationDAO.Instance.UpdateBookingReservation(br);

        public void DeleteBookingReservation(BookingReservation br)
            => BookingReservationDAO.Instance.DeleteBookingReservation(br);

        public IEnumerable<object> GetBookingReservationsWithCustomerName()
            => BookingReservationDAO.Instance.GetBookingReservationsWithCustomerName();

        public List<object> SearchBookingsByDateRange(DateTime? startDate, DateTime? endDate)
            => BookingReservationDAO.Instance.SearchBookingsByDateRange(startDate, endDate);
    }
}
