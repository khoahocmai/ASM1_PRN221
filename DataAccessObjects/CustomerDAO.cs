using BusinessObjects;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Net.WebSockets;

namespace DataAccess
{
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        private static object lockObject = new object();
        private FUMiniHotelManagementContext db = new FUMiniHotelManagementContext();

        private CustomerDAO() { }

        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerDAO();
                }
                return instance;
            }
        }
        public Customer? CheckLogin(string email, string password)
        {
            return db.Customers.SingleOrDefault(m => m.EmailAddress == email && m.Password == password);
        }

        public List<Customer> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            var temp = GetAllCustomers().SingleOrDefault(m => m.CustomerId == id);
            return temp;
        }

        public List<Customer> GetCustomersByName(string searchString)
        {
            var temp = GetAllCustomers()
                                    .Where(m => m.CustomerFullName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                                    .ToList();
            return temp;
        }

        public List<Customer> GetCustomerByEmail(string searchString)
        {
            var temp = GetAllCustomers().Where(m => m.EmailAddress.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            return temp;
        }

        public List<Customer> GetCustomersByStatus(byte status)
        {
            var temp = GetAllCustomers()
                            .Where(m => m.CustomerStatus == status)
                            .ToList();
            return temp;
        }

        //thêm customer
        public void SaveCustomer(Customer c)
        {
            db.Customers.Add(c);
            db.SaveChanges();
        }

        //Cập nhật thông tin customer
        public void UpdateCustomer(Customer c)
        {
            db.Customers.Update(c);
            db.SaveChanges();
        }

        //xóa Cus
        public void DeleteCustomer(Customer c)
        {
            var foundedCustomer = db.Customers.SingleOrDefault(m => m.CustomerId == c.CustomerId);
            db.Customers.Remove(foundedCustomer);
            db.SaveChanges();
        }

        public bool IsEmailExists(string email)
        {
            var tmp = GetAllCustomers().SingleOrDefault(c => c.EmailAddress == email);
            return tmp != null;
        }

        public bool IsPhoneExists(string phone)
        {
            var tmp = GetAllCustomers().SingleOrDefault(c => c.Telephone == phone);
            return tmp != null;
        }
    }
}
