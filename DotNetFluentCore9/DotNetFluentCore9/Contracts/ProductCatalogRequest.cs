namespace DotNetFluentCore9.Contracts
{
    public class ProductItem
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }

    public class ProductCatalogRequest
    {
        public string? StoreName { get; set; }
        public List<ProductItem> Products { get; set; } = new();
    }

}
