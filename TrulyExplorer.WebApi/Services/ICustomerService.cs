using TrulyExplorer.WebApi.HotelDto;
using TrulyExplorer.WebApi.Models;

namespace TrulyExplorer.WebApi.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int id);
        void AddCustomer(CustomerDTO customer);
        void UpdateCustomer(CustomerDTO customer);
        void DeleteCustomer(int id);
    }
}


