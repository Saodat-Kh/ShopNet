using Domain.Entities;
namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    bool CreateCustomer(Customer customer);
    bool UpdateCustomer(Customer customer);
    bool DeleteCustomer(int customerId);
    Customer GetCustomerById(int customerId);
    List<Customer> GetAllCustomers();
}