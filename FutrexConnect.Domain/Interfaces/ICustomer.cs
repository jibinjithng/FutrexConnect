using FutrexConnect.Domain.DAO;
using FutrexConnect.Domain.Entities;

namespace FutrexConnect.Domain.Interfaces
{
    public interface ICustomer
    {
        Task<IEnumerable<CustomerDAO>> GetAllCustomers();

        Task<CustomerDAO> GetCustomerByID(long customerID);

        Task<CustomerDAO> CreateCustomer(CustomerDAO customer);

        Task<CustomerDAO> UpdateCustomer(CustomerDAO customer);

        Task<Boolean> DeleteCustomer(long customerID);
    }
}