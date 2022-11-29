using System;
namespace API.Models
{
    public class Books
    {
        public int BookID{get;set;}
        public string Title{get;set;}
        public string Author{get;set;}
        public int ISBN{get;set;}
        public string Condition{get; set;}
        public string Genre {get; set;}

        public int Deleted {get; set;}

        public double Price {get; set;}

        public DateTime DateAdded {get; set;}

        public string VendororCustomerName{get; set;}

        public override string ToString()
        {
            return "Book ID: "+ this.BookID +" "+ " Title: "+ this.Title +" " + " Author: " + this.Author + " ISBN " + this.ISBN + "Conditon" + this.Condition + "Genre" + this.Genre + "Price" + this.Price + "VendororCustomerName" + this.VendororCustomerName;
        }

    }
}