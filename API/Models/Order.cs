namespace API.Models
{
    public class Order
    {
        public int TotalAmount{get;set;}
        public DateTime OrdDateTime{get;set;}
        public int OrderID {get;set;}
        public int Cust_id {get;set;}
        public int EmpId {get;set;}
    }
}