namespace EfWithWebAPI
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        
    }
}
