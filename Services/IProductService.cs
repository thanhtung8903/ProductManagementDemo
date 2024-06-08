using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        void SaveProduct(Product p);

        void UpdateProduct(Product p);

        void DeleteProduct(Product p);

        Product GetProductById(int id);

        ObservableCollection<Product> GetProducts();

    }
}
