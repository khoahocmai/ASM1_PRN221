using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingReservationDAO
    {
        private static BookingReservationDAO instance = null;
        private static object lockObject = new object();
        private FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

        private BookingReservationDAO() { }

        public static BookingReservationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingReservationDAO();
                }
                return instance;
            }
        }

        //có thể trả ra nhiều bookingReser của 1 khách hàng
        public List<BookingReservation> GetBookingReservationsByCusID(int cusId)
        {
            var reservations = db.BookingReservations.Where(m => m.CustomerId == cusId).ToList();
            return reservations;
        }

        public List<BookingReservation> GetAllBookingReservation()
        {
            return db.BookingReservations.ToList();
        }

        public BookingReservation GetBookingReservation(int bookingId)
        {
            var temp = db.BookingReservations.SingleOrDefault(m => m.BookingReservationId == bookingId);
            return temp;
        }

        //thêm BookingReservation
        public void SaveBookingReservation(BookingReservation br)
        {
            db.BookingReservations.Add(br);
            db.SaveChanges();
        }

        //Cập nhật thông tin BookingReservation
        public void UpdateBookingReservation(BookingReservation br)
        {
            db.BookingReservations.Update(br);
            db.SaveChanges();
        }

        //xóa BookingReservation
        public void DeleteBookingReservation(BookingReservation br)
        {
            var foundedBookingReservation = db.BookingReservations.SingleOrDefault(m => m.BookingReservationId == br.BookingReservationId);
            db.BookingReservations.Remove(foundedBookingReservation);
            db.SaveChanges();
        }

        public IEnumerable<object> GetBookingReservationsWithCustomerName()
        {
            var query = from br in db.BookingReservations
                        join c in db.Customers on br.CustomerId equals c.CustomerId
                        select new
                        {
                            br.BookingReservationId,
                            br.BookingDate,
                            br.TotalPrice,
                            CustomerName = c.CustomerFullName,
                            br.BookingStatus
                        };
            return query.ToList();
        }

        public List<object> SearchBookingsByDateRange(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null || startDate > endDate)
            {
                throw new ArgumentException("Ngày không hợp lệ");
            }

            var bookingsWithCustomerNames = (from booking in db.BookingReservations
                                             join customer in db.Customers on booking.CustomerId equals customer.CustomerId
                                             where booking.BookingDetails.Any(detail => detail.StartDate >= startDate && detail.EndDate <= endDate)
                                             select new
                                             {
                                                 booking.BookingReservationId,
                                                 booking.BookingDate,
                                                 booking.TotalPrice,
                                                 booking.BookingStatus,
                                                 CustomerName = customer.CustomerFullName
                                             }).ToList<object>();

            return bookingsWithCustomerNames;
        }
    }
}
