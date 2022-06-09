using CRUDORM.Data;
using CRUDORM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDORM.Business
{
    public class ProductBusiness
    {
        private ProductContext _productContext; //BD mi tryabva
       
        public List<Product> GetAll()
        {
            using (_productContext=new ProductContext())
            {
                List<Product> listProducts = _productContext.Products.ToList();
                return listProducts;
            }   
           
        }

        public Product Get(int id)
        {
            using (_productContext = new ProductContext())
            {
                Product buffer = _productContext.Products.Find(id);
                return buffer;
            }
        }

        public void Add(Product product)
        {
            using (_productContext = new ProductContext())
            {
                _productContext.Products.Add(product);
                _productContext.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (_productContext = new ProductContext())
            {

                var item = _productContext.Products.Find(product.Id);
                if (item != null)
                {
                    _productContext.Entry(item).CurrentValues.SetValues(product);
                    _productContext.SaveChanges();
                }

            }
        }

        public void Delete(int id)
        {
            using (_productContext = new ProductContext())
            {
                var product = _productContext.Products.Find(id);
                if (product != null)
                {
                    _productContext.Products.Remove(product);
                    _productContext.SaveChanges();
                }
            }
        }
    }
}
