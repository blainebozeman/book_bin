// using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
namespace API.Models.Interfaces
{
    public interface IGetAllBooks
    {
        List<Books> GetAllBooks();
    }
}