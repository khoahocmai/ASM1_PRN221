using BusinessObjects;
using DataAccess;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        public Customer? CheckLogin(string email, string password)
            => CustomerDAO.Instance.CheckLogin(email, password);

        public List<Customer> GetAllCustomers()
            => CustomerDAO.Instance.GetAllCustomers();

        public Customer? GetCustomerById(int id)
            => CustomerDAO.Instance.GetCustomerById(id);

        public List<Customer> GetCustomerByName(string searchString)
            => CustomerDAO.Instance.GetCustomersByName(searchString);

        public List<Customer> GetCustomerByEmail(string searchString)
            => CustomerDAO.Instance.GetCustomerByEmail(searchString);

        public List<Customer> GetCustomerByStatus(byte searchString)
            => CustomerDAO.Instance.GetCustomersByStatus(searchString);

        public void SaveCustomer(Customer c)
            => CustomerDAO.Instance.SaveCustomer(c);

        public void UpdateCustomer(Customer c)
            => CustomerDAO.Instance.UpdateCustomer(c);

        public void DeleteCustomer(Customer c)
            => CustomerDAO.Instance.DeleteCustomer(c);

        public bool IsEmailExists(string email)
            => CustomerDAO.Instance.IsEmailExists(email);

        public bool IsPhoneExists(string phone)
            => CustomerDAO.Instance.IsPhoneExists(phone);
    }
}
