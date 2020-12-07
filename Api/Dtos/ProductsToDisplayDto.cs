namespace Api.Dtos
{
    public class ProductsToDisplayDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}