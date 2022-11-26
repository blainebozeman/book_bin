namespace API.Models.Interfaces
{
    public interface IGetCustomer
    {
         List<Customer> GetSelect(Customer customer);
    }
}