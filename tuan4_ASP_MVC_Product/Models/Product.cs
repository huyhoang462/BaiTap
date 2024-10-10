namespace tuan4_ASP_MVC_Product.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int? CatalogId { get; set; }

        public string? ProductCode { get; set; }

        public string? ProductName { get; set; }

        public string? Picture { get; set; }

        public double? UnitPrice { get; set; }

        public virtual Catalog? Catalog { get; set; }
    }
}
