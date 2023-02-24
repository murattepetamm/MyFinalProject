using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
                {
                    new Product{ProductId=1,CategoryId=1,ProductName="Mouse",UnitPrice=15,UnitsInStock=15},
                    new Product{ProductId=2,CategoryId=1,ProductName="Klavye",UnitPrice=500,UnitsInStock=30},
                    new Product{ProductId=3,CategoryId=2,ProductName="Kamera",UnitPrice=1500,UnitsInStock=25},
                    new Product{ProductId=4,CategoryId=2,ProductName="Monitör",UnitPrice=150,UnitsInStock=6},
                    new Product{ProductId=5,CategoryId=2,ProductName="Kasa",UnitPrice=85,UnitsInStock=1}

                };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product productUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productUpdate.CategoryId = product.CategoryId;
            productUpdate.ProductName = product.ProductName;
            productUpdate.UnitsInStock = product.UnitsInStock;
            productUpdate.UnitPrice = product.UnitPrice;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
