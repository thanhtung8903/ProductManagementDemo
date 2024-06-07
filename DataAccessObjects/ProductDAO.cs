using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        public static List<Product> listProducts = new List<Product>();


        public ProductDAO()
        {
            Product chai = new Product(1, "Chai", 3, 12, 18);
            Product chang = new Product(2, "Chang", 1, 23, 19);
            Product aniseed = new Product(3, "Aniseed Syrup", 2, 23, 10);

            listProducts = new List<Product> { chai, chang, aniseed };
        }

        public static List<Product> GetProducts()
        {
            return listProducts;
        }

        //public static List<Product> GetProducts()
        //{
        //    var listProducts = new List<Product>();
        //    try
        //    {
        //        using var db = new MyStoreContext();
        //    }
        //}

        public static void SaveProduct(Product product)
        {
            listProducts.Add(product);
        }

        public static void UpdateProduct(Product product)
        {
          foreach (Product p in listProducts)
            {
                if (p.ProductID == product.ProductID)
                {
                    p.ProductID = product.ProductID;
                    p.ProductName = product.ProductName;
                    p.CategoryId = product.CategoryId;
                    p.UnitsInStock = product.UnitsInStock;
                    p.UnitPrice = product.UnitPrice;
                }
            }
        }

        public static void DeleteProduct(Product product)
        {
            foreach (Product p in listProducts)
            {
                if (p.ProductID == product.ProductID)
                {
                    listProducts.Remove(p);
                }
            }
        }

        public static Product GetProductById(int id)
        {
            foreach (Product p in listProducts)
            {
                if (p.ProductID == id)
                {
                    return p;
                }
            }
            return null;
        }



    }
}
