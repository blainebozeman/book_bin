namespace API.Models
{
    public class Customer
    {
        public Guid CustID{get;set;}
        public string CustUserName {get;set;}
        public string CustPassword {get;set;}
        public string FName {get;set;}
        public string LName {get;set;}
        public int Credits{get;set;}
        public int Emp_ID{get;set;}
    }
}