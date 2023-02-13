namespace MobilePoint.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User Users { get; set; }
        public int PhoneId { get; set; }
        public Phone Phones { get; set; }
        public int Quantity { get; set;}
        public DateTime RegisterOn { get; set; }
    }
}
