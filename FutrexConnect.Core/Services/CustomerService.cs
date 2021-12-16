using AutoMapper;
using FutrexConnect.Domain.DAO;
using FutrexConnect.Domain.Entities;
using FutrexConnect.Domain.Interfaces;

namespace FutrexConnect.Core.Services
{
    public class CustomerService : ICustomer
    {
        IRepository<Customer> _customerRepository;
        ILogger<CustomerService> _logger;
        private readonly IMapper _mapper;
        public CustomerService(ILogger<CustomerService> logger, IMapper mapper, IRepository<Customer> customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerDAO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDAO>>(customers);
        }

        public async Task<CustomerDAO> GetCustomerByID(long customerID)
        {
            var customer = await _customerRepository.GetAsync(customerID);
            return _mapper.Map<CustomerDAO>(customer);
        }

        public Task<Customer> CreateCustomer(Customer customer)
        {
            customer.CreatedOn = DateTime.Now;
            customer.ModifiedOn = DateTime.Now;
            return _customerRepository.AddAsync(customer);
        }

        public Task<Customer> UpdateCustomer(Customer customer)
        {
            customer.ModifiedOn = DateTime.Now;
            return _customerRepository.UpdateAsync(customer);
        }
        public async Task<Boolean> DeleteCustomer(long customerID)
        {
            var customer = await _customerRepository.GetAsync(customerID);

            if (customer == null)
            {
                return false;
            }
            _customerRepository.DeleteAsync(customer);
            return true;
        }
    }
}