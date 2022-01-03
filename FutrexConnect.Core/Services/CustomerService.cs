using AutoMapper;
using FutrexConnect.Domain.DAO;
using FutrexConnect.Domain.Entities;
using FutrexConnect.Domain.Interfaces;
using System.Linq;

namespace FutrexConnect.Core.Services
{
    public class CustomerService : ICustomer
    {
        IRepository<Customer> _customerRepository;
        IRepository<CustomerAddressDetails> _customerAddressRepository;

        IRepository<CustomerContactDetails> _customerContactRepository;

        ILogger<CustomerService> _logger;
        private readonly IMapper _mapper;
        public CustomerService(ILogger<CustomerService> logger, IMapper mapper,
            IRepository<Customer> customerRepository,
            IRepository<CustomerAddressDetails> customerAddressRepository,
            IRepository<CustomerContactDetails> customerContactRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _customerAddressRepository = customerAddressRepository;
            _customerContactRepository = customerContactRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerDAO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            System.Threading.Thread.Sleep(2000);
            return _mapper.Map<IEnumerable<CustomerDAO>>(customers);
        }

        public async Task<CustomerDAO> GetCustomerByID(long customerID)
        {
            var selectCustomerTaskResult = await Task.Run(() =>
            {
                return (from c in _customerRepository.GetAll()
                        join ca in _customerAddressRepository.GetAll()
                            on c.Id equals ca.CustomerId into customerAddress
                        from cca in customerAddress.DefaultIfEmpty()
                        join cc in _customerContactRepository.GetAll()
                            on c.Id equals cc.CustomerId into customerContact
                        from ccacc in customerContact.DefaultIfEmpty()
                        where c.Id == customerID
                        select new CustomerDAO
                        {
                            Id = c.Id,
                            CustomerName = c.CustomerName,
                            CustomerType = c.CustomerType,
                            Website = c.Website,
                            CustomerAddressDetails = new List<CustomerAddressDetailsDAO>()
                        {
                            cca == null ? new CustomerAddressDetailsDAO {} :
                            new CustomerAddressDetailsDAO{
                                Id = cca.Id,
                                Address1 = cca.Address1,
                                Address2 = cca.Address2,
                                CityId = cca.CityId,
                                StateId = cca.StateId.HasValue ? cca.StateId.Value : 0,
                                CountryId = cca.CountryId.HasValue ? cca.CountryId.Value : 0,
                                Pincode = cca.PinCode,
                            }
                        },
                            CustomerContactDetails = new List<CustomerContactDetailsDAO>()
                        {
                            ccacc == null ? new CustomerContactDetailsDAO {} :
                            new CustomerContactDetailsDAO{
                                Id = ccacc.Id,
                                Email = ccacc.Email,
                                MobilePhone = ccacc.MobilePhone,
                                OfficePhone = ccacc.OfficePhone,
                            }
                        }
                        }).FirstOrDefault();
            });

            if (selectCustomerTaskResult == null)
                throw new NullReferenceException();
            else
            {
                selectCustomerTaskResult.CustomerAddressDetails = new List<CustomerAddressDetailsDAO>(){
                    selectCustomerTaskResult.CustomerAddressDetails.FirstOrDefault<CustomerAddressDetailsDAO>(new CustomerAddressDetailsDAO())
                };
                selectCustomerTaskResult.CustomerContactDetails = new List<CustomerContactDetailsDAO>(){
                    selectCustomerTaskResult.CustomerContactDetails.FirstOrDefault<CustomerContactDetailsDAO>(new CustomerContactDetailsDAO())
                };
            }

            return selectCustomerTaskResult;
        }

        public async Task<CustomerDAO> CreateCustomer(CustomerDAO customerDAO)
        {
            var customer = _mapper.Map<Customer>(customerDAO);
            customer.CreatedOn = DateTime.Now;
            customer.ModifiedOn = DateTime.Now;

            await _customerRepository.AddAsync(customer);
            return _mapper.Map<CustomerDAO>(customer);
        }

        public async Task<CustomerDAO> UpdateCustomer(CustomerDAO customerDAO)
        {
            var customer = _mapper.Map<Customer>(customerDAO);
            customer.ModifiedOn = DateTime.Now;
            await _customerRepository.UpdateAsync(customer);

            var customerAddress = customer.AddressDetails.FirstOrDefault();
            if (customerAddress != null)
            {
                customerAddress.ModifiedOn = DateTime.Now;
                await _customerAddressRepository.UpdateAsync(customerAddress);
            }
            var customerContactDetails = customer.ContactDetails.FirstOrDefault();
            if (customerContactDetails != null)
            {
                customerContactDetails.ModifiedOn = DateTime.Now;
                await _customerContactRepository.UpdateAsync(customerContactDetails);
            }
            return _mapper.Map<CustomerDAO>(customer);
        }
        public async Task<Boolean> DeleteCustomer(long customerID)
        {
            var customer = await _customerRepository.GetAsync(customerID);

            if (customer == null)
            {
                return false;
            }
            await _customerRepository.DeleteAsync(customer);
            return true;
        }
    }
}