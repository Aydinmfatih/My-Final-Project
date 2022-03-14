using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
            new Product{ProductId=1,CategoryId=1,ProductName="bardak",UnitPrice=15,UnitsInStock=2},
            new Product{ProductId=2,CategoryId=2,ProductName="masa",UnitPrice=65,UnitsInStock=2},
            new Product{ProductId=3,CategoryId=1,ProductName="telefon",UnitPrice=1555,UnitsInStock=2},
            new Product{ProductId=4,CategoryId=6,ProductName="Klavye",UnitPrice=125,UnitsInStock=2},
            new Product{ProductId=5,CategoryId=1,ProductName="fare",UnitPrice=152,UnitsInStock=2}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var DeleteToProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(DeleteToProduct);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
          var  result=  _products.Where(p => p.CategoryId == CategoryId).ToList();
            return result;

        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
