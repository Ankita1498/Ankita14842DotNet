using System;
using System.Linq;

namespace EFCodeFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //  SeedDataBase();
            
            EFCodeFirstDBContext db = new EFCodeFirstDBContext();
            //search for record with ProductId=101
            Product product = db.Products.SingleOrDefault(p => p.ProductId == 101);
            //product

            //if(product !=null)
            //{
            //    product.ProductName = "mobile";
            //    product.Price = 300000;
            //    db.SaveChanges();
            //    Console.WriteLine("Record updated");
            //}
            //else
            //{
            //    Console.WriteLine("Not Found");
            //}

            //delete
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                Console.WriteLine("Record deleted");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        private static void SeedDataBase()
        {
            EFCodeFirstDBContext db = new EFCodeFirstDBContext();

            Category category1 = new Category()
            {
                CategoryId = 1,
                CategoryName = "Electronics"
            };
            db.Categories.Add(category1);
            db.SaveChanges();

            Product product1 = new Product()
            {
                ProductId = 101,
                ProductName = "Laptop",
                Category = category1,
                Price=1000
            };
            db.Products.Add(product1);
            db.SaveChanges();
        }
    }
}
