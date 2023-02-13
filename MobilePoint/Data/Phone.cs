namespace MobilePoint.Data
{
    public class Phone
    {
        public int Id { get; set; }
        public int BrandModelId { get; set; }
        public BrandModel BrandModels { get; set; }   
        public string Color { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisterOn { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
