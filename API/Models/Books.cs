using System;
namespace API.Models
{
    public class Books
    {
        public int BookID{get;set;}
        public string Title{get;set;}
        public string Author{get;set;}
        public string ISBN{get;set;}
        public int Condition {get; set;}

        public bool Deleted {get; set;}

        public int Price {get; set;}

        public DateTime DateAdded {get; set;}

        public override string ToString()
        {
            return "Book ID: "+ this.BookID +" "+ " Title: "+ this.Title +" " + " Author: " + this.Author + " ISBN " + this.ISBN + "Conditon" + this.Condition + "Price" + this.Price;
        }

    }
}