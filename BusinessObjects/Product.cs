using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public partial class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }
        public virtual Category Category { get; set; }

        public Product(int id, string name, int catId, int unitInStock, int price)
        {
            this.ProductID = id;
            this.ProductName = name;
            this.CategoryId = catId;
            this.UnitsInStock = unitInStock;
            this.UnitPrice = price;
        }

        public Product()
        {
        }
    }
}
