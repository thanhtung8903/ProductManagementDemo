using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        public static ObservableCollection<Product> ListProducts = InitializeProducts();
        private static int nextProductId = 4; 
        
        private static ObservableCollection<Product> InitializeProducts()
        {
            Product chai = new Product(1, "Chai", 3, 12, 18);
            Product chang = new Product(2, "Chang", 1, 23, 19);
            Product aniseed = new Product(3, "Aniseed Syrup", 2, 23, 10);

            return new ObservableCollection<Product> { chai, chang, aniseed };
        }

        public static ObservableCollection<Product> GetProducts()
        {
            return ListProducts;
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
            product.ProductID = nextProductId;
            nextProductId++;
            ListProducts.Add(product);
        }

        public static void UpdateProduct(Product product)
        {
            for (int i = 0; i < ListProducts.Count; i++)
            {
                if (ListProducts[i].ProductID == product.ProductID)
                {
                    ListProducts[i] = product;
                    return;
                }
            }
        }

        public static void DeleteProduct(Product product)
        {
            var productsToRemove = ListProducts.Where(p => p.ProductID == product.ProductID).ToList();
            foreach (var p in productsToRemove)
            {
                ListProducts.Remove(p);
            }
        }

        public static Product GetProductById(int id)
        {
            foreach (Product p in ListProducts)
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
