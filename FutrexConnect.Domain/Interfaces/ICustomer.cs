using FutrexConnect.Domain.DAO;
using FutrexConnect.Domain.Entities;

namespace FutrexConnect.Domain.Interfaces
{
    public interface ICustomer
    {
        Task<IEnumerable<CustomerDAO>> GetAllCustomers();

        Task<CustomerDAO> GetCustomerByID(long customerID);

        Task<Customer> CreateCustomer(Customer customer);

        Task<Customer> UpdateCustomer(Customer customer);

        Task<Boolean> DeleteCustomer(long customerID);
    }
}