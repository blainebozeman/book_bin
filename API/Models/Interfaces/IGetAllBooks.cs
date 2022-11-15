// using Microsoft.AspNetCore.Cors;
namespace API.Models.Interfaces
{
    public interface IGetAllBooks
    {
        List<Books> GetAllBooks();
    }
}