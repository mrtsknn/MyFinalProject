// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//SOLID
//Open closed principle
ProductManager productManager = new ProductManager(new EfProfuctDal());

foreach (var product in productManager.GetByUnitPrice(50,100))
{
    Console.WriteLine(product.ProductName);
}