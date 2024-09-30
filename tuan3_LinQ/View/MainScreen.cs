using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tuan3_LinQ.Model;

namespace tuan3_LinQ
{
    public partial class MainScreen : Form
    {
        private ProductRepository repository;
        public MainScreen()
        {
            InitializeComponent();
            repository = new ProductRepository();
        }
        private bool isValidProduct()
        {
            string id = tbx_id.Text;
            string name = tbx_name.Text;
            double price = 0;
            string origin = tbx_origin.Text;
            int number = 0;
            if (string.IsNullOrEmpty(id)) return false;
            if (string.IsNullOrEmpty(name)) return false;
            if (string.IsNullOrEmpty(origin)) return false;
            try
            {
                number = int.Parse(tbx_number.Text);
            }
            catch
            {
                return false;
            }
            try
            {
                price = double.Parse(tbx_price.Text);
            }
            catch
            {
                return false;
            }
            if (price <= 0) return false;
            if (number < 0) return false;


            return true;
        }
        private void MainScreen_Load(object sender, EventArgs e)
        {
            updateDataGridView();
        }
        private void updateDataGridView()
        {
            // Giả sử bạn đã khai báo repository là một đối tượng của ProductRepository
            list_all.Rows.Clear();
            var products = repository.GetAllProducts();
            foreach (var product in products)
            {
                list_all.Rows.Add(product.getId(), product.getName(), product.getNumber(), product.getPrice(), product.getOrigin(), product.getOverdue());
            }
        }
        // lưu hoặc chỉnh sửa thông tin
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (isValidProduct())
            {
                
                Product product = new Product(tbx_id.Text, tbx_name.Text, int.Parse(tbx_number.Text), double.Parse(tbx_price.Text), tbx_origin.Text, tbx_overdue.Value);
                var existProduct = repository.GetAllProducts().Find(p => p.getId() == tbx_id.Text);
                if (existProduct != null) // id đã tồn tại
                {
                    repository.UpdateProduct(product);
                    updateDataGridView();
                    MessageBox.Show("Một sản phẩm đã được chỉnh sửa.");
                    return;
                }
                    repository.AddProduct(product);
                updateDataGridView();
                MessageBox.Show("Một sản phẩm đã được thêm vào.");

            }
        }
        // xóa bỏ sản phẩm
        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (isValidProduct())
            {
                string prdId = tbx_id.Text;
                var existProduct = repository.GetAllProducts().Find(p => p.getId() == prdId);
                if (existProduct != null)
                {
                    repository.DeleteProduct(prdId);
                    updateDataGridView();
                    MessageBox.Show("Một sản phẩm đã bị xóa.");
                }

            }


        }
        // 1 sản phẩm có giá cao nhất
        private void btn_highest_price_Click(object sender, EventArgs e)
        {
            var product = repository.getHighestPrice();
            list_search.Rows.Clear();
            if(product!= null)
            list_search.Rows.Add(product.getId(), product.getName(), product.getNumber(), product.getPrice(), product.getOrigin(), product.getOverdue());

        }
        // 1 sản phẩm có xuất xứ nhật bản
        private void btn_from_Japan_Click(object sender, EventArgs e)
        {
            var product = repository.getProductFrom("Nhật bản");
                list_search.Rows.Clear();
            if (product != null)
            {
                list_search.Rows.Add(product.getId(), product.getName(), product.getNumber(), product.getPrice(), product.getOrigin(), product.getOverdue());

            }
            else MessageBox.Show("Không có sản phẩm đến từ Nhật Bản");

        }
        // toàn bộ sản phẩm quá hạn
        private void btn_overdue_Click(object sender, EventArgs e)
        {
            var overdueProducts = repository.getProductsOverdue();
                list_search.Rows.Clear();
            if (overdueProducts != null)
            {
                overdueProducts.ForEach(product => list_search.Rows.Add(product.getId(), product.getName(), product.getNumber(), product.getPrice(), product.getOrigin(), product.getOverdue()));
            }
            else MessageBox.Show("Không có sản phẩm nào quá hạn.");

        }
        // các sản phẩm có đơn giá trong khoảng a_b
        private void btn_inRange_Click(object sender, EventArgs e)
        {
            double min = 0, max = 0;
            try
            {
                min = double.Parse(tbx_from.Text);
                max = double.Parse(tbx_to.Text);
            }
            catch { MessageBox.Show("Khoảng giá trị không đúng"); }
            if (min > max)
            {
                MessageBox.Show("Giá trị a không được lớn hơn giá trị b.");
                return;
            }
            var products = repository.getProductsInRange(min, max);
            list_search.Rows.Clear();
            if (products != null)
            {
                foreach (var product in products)
                    list_search.Rows.Add(product.getId(), product.getName(), product.getNumber(), product.getPrice(), product.getOrigin(), product.getOverdue());

            }
            else MessageBox.Show("Không có sản phẩm thỏa mãn.");

        }
        // xóa sp xuất xứ bất kì
        private void btn_remove_from_Click(object sender, EventArgs e)
        {
            string origin = tbx_remove_from.Text;
            if (string.IsNullOrEmpty(origin))
                {
                MessageBox.Show("Hãy nhập xuất xứ trước.");
                    return;
            }
            else
            {
                var product = repository.GetAllProducts().Find(p => p.getOrigin().ToLower() == origin.ToLower());
                if (product != null)
                { repository.removeProductsFrom(origin);
                    updateDataGridView();
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào đến từ " + origin);
                }

            }
        }
        // kiểm tra có sản phẩm quá hạn không
        private void btn_is_overdue_Click(object sender, EventArgs e)
        {
            int numb = repository.isOverdue();
            if (numb > 0)
                MessageBox.Show("Kho có " + numb + " sản phẩm quá hạn.");
            else MessageBox.Show("Không có sản phẩm quá hạn.");
        }
        // xóa toàn bộ sản phẩm
        private void btn_remove_all_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả sản phẩm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                repository.removeAll();
                updateDataGridView();
            }
           
        }
        // xóa sản phẩm quá hạn
        private void btn_remove_overdue_Click(object sender, EventArgs e)
        {
            var products = repository.getProductsOverdue();
            if (products != null)
            {
                repository.removeProductsOverdue();
                updateDataGridView();
            }
            else MessageBox.Show("Không có sản phẩm quá hạn.");
        }

        //
    }
}
