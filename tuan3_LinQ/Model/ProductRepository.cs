using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan3_LinQ.Model
{
    internal class ProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {

            _products = new List<Product>
            { new Product("sp1","Sữa Vinamlik",400,36000,"Việt Nam",DateTime.Now.Date),
             new Product("sp2","Takoyaki",280,40000,"Nhật Bản",DateTime.Now.Date),
             new Product("sp3","Bing chilling",1000,10000,"China",DateTime.Now.Date)
            };
        }

        // Lấy tất cả sản phẩm
        public List<Product> GetAllProducts()
        {
            return _products;
        }

        // Thêm sản phẩm mới
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Sửa sản phẩm
        public void UpdateProduct(Product product)
        {
            var existingProduct = _products.Find(p => p.getId() == product.getId());
            if (existingProduct != null)
            {
                existingProduct.setName(product.getName());
                existingProduct.setPrice(product.getPrice());
                existingProduct.setNumber(product.getNumber());
                existingProduct.setOrigin(product.getOrigin());
            }
        }

        // Xóa sản phẩm
        public void DeleteProduct(string productId)
        {
            var product = _products.Find(p => p.getId() == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
        //1 Sản phẩm có đơn giá cao nhất
        public Product getHighestPrice()
        {
            double price = 0;
            string id = "";
            foreach (var product in _products)
            {
                if (product.getPrice() > price)
                {
                    price = product.getPrice();
                    id = product.getId();
                }
            }
            var result = _products.Find(p => p.getId() == id);
            return (Product)result;
        }
        // 1 sản phẩm đến từ...
        public Product getProductFrom(string origin)
        {
            var product = _products.Find(p=> p.getOrigin().ToLower() == origin.ToLower());
            return (Product)product;
        }
        // tất cả sản phẩm quá hạn
        public List<Product> getProductsOverdue()
        {
            DateTime dateNow = DateTime.Now.Date;
            var products= _products.FindAll(p => p.getOverdue() < dateNow);
            return products;
        }
        // sản phẩm trong khoảng giá a..b
        public List<Product> getProductsInRange(double min, double max)
        {
            var products = _products.FindAll(p=> p.getPrice()>=min && p.getPrice()<=max);
            return products;
        }
        // xóa sản phẩm đến từ...
        public void removeProductsFrom(string origin)
        {
            _products.RemoveAll(p=>p.getOrigin().ToLower() == origin.ToLower());    
        }
        // kiểm tra có sản phẩm quá hạn
        public int isOverdue()
        {
            DateTime dateNow = DateTime.Now.Date;
            var products = _products.FindAll(p => p.getOverdue() < dateNow);
            return products.Count();
        }
        // xóa toàn bộ sản phẩm
        public void removeAll()
        {
            _products.Clear();
        }
        // xóa sản phẩm quá hạn
        public void removeProductsOverdue()
        {
            DateTime dateNow = DateTime.Now.Date;
            _products.RemoveAll(p => p.getOverdue() < dateNow);

        }
    }
}
