namespace tuan4_ASP_MVC_Product.Models
{
    public class Catalog
    {
        public int Id { get; set; }

        public string? CatalogCode { get; set; }

        public string? CatalogName { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
