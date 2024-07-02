using bilet5Khromov.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilet5Khromov.Services
{
    public class ProductService
    {
        public List<Product> GetProducts()
        {
            using (var context = new bilet5KhromovEntities())
            {
                return context.Product.ToList();
            }
        }

        public void AddProduct(Product product)
        {
            using (var context = new bilet5KhromovEntities())
            {
                context.Product.Add(product);
                context.SaveChanges();
            }
        }

        public void EditProduct(Product product)
        {
            using (var context = new bilet5KhromovEntities())
            {
                var existingProduct = context.Product.Find(product.idProduct);
                if (existingProduct != null)
                {
                    existingProduct.name = product.name;
                    existingProduct.type = product.type;
                    existingProduct.price = product.price;
                    existingProduct.weightGr = product.weightGr;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var context = new bilet5KhromovEntities())
            {
                var product = context.Product.Find(productId);
                if (product != null)
                {
                    context.Product.Remove(product);
                    context.SaveChanges();
                }
            }
        }
    }
}
