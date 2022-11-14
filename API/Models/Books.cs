namespace API.Models
{
    public class Books
    {
        public Guid BookID{get;set;}
        public string Title{get;set;}
        public string Author{get;set;}
        public string ISBN{get;set;}
        public string Condition {get; set;}

        public override string ToString()
        {
            return "Book ID: "+ this.BookID +" "+ " Title: "+ this.Title +" " + " Author: " + this.Author + " ISBN " + this.ISBN + "Conditon" + this.Condition ;
        }

    }
}