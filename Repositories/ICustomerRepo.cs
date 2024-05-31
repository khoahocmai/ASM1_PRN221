using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepo
    {
        public Customer? CheckLogin(string email, string password);

        public List<Customer> GetAllCustomers();

        public Customer? GetCustomerById(int id);

        public List<Customer> GetCustomerByName(string searchString);

        public List<Customer> GetCustomerByEmail(string searchString);

        public List<Customer> GetCustomerByStatus(byte searchString);

        public void SaveCustomer(Customer c);

        public void UpdateCustomer(Customer c);

        public void DeleteCustomer(Customer c);

        public bool IsEmailExists(string email);

        public bool IsPhoneExists(string phone);
    }
}
