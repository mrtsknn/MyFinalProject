using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //Buraya InMemoryProductDal yazdık çünkü IProductDal'ı implemente eden sınıfın ismi bu olacak.
    //Diğerlerini yazmadık çünkü onlara üşendim :)
    //Zaten az sonra EntityFrameworkProductDal'ı yazacağız.
    //Hatta üşenmeden oluşturayım
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //Global değişken
        public InMemoryProductDal()
        {
            _products=new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Masa",UnitPrice=15,UnitsInStock=15 },
                new Product{ProductId=2,CategoryId=1,ProductName="Sandalye",UnitPrice=50,UnitsInStock=60 },
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=15000,UnitsInStock=650 },
                new Product{ProductId=4,CategoryId=2,ProductName="Bilgisayar",UnitPrice=150000,UnitsInStock=100 },
                new Product{ProductId=5,CategoryId=2,ProductName="Tablet",UnitPrice=3000,UnitsInStock=10 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /*LINQ olmasaydı bu şekilde yapacaktık
            Product productToDelete;
            foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                {
                    productToDelete = p;
                }
            }*/
            //UNUTMA BU BİR TEKRAR HER DETAY ÖNEMLİ
            //-------------------------------------------
            //LINQ - Language Integrated Query
            product = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            /*LINQ olmasaydı bu şekilde yapacaktık
            Product productToUpdate;
            foreach (var p in _products)
            {
                if (p.ProductId == product.ProductId)
                {
                    productToUpdate = p;
                    productToUpdate.ProductName = product.ProductName;
                    productToUpdate.CategoryId = product.CategoryId;
                    productToUpdate.UnitPrice = product.UnitPrice;
                    productToUpdate.UnitsInStock = product.UnitsInStock;
                }
            }*/
            //UNUTMA BU BİR TEKRAR HER DETAY ÖNEMLİ
            //-------------------------------------------
            //LINQ - Language Integrated Query
            Product productToUpdate = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock=product.UnitsInStock;
        }
    }
}
