namespace API.Models.Interfaces
{
    public interface IAddCustomer
    {
        List<Customer> PutCustomer(Customer user);
    }
}