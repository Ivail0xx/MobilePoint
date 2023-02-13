namespace MobilePoint.Data
{
    public class BrandModel
    {
       public int Id { get; set; }
       public string Brand { get; set; }
       public string Model { get; set; }
      public string Specification { get; set; }
        public DateTime RegisterOn { get; set; }
        public ICollection<BrandModel> BrandModels { get;set; }
    }
}
