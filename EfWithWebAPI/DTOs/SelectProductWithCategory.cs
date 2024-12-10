namespace EfWithWebAPI.DTOs
{
    public class SelectProductWithCategory
    {
        public int ProductId { get; set; } = 0;
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public int CategoryId { get; set; } = 0;
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
