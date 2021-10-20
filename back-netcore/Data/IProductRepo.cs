using System.Collections.Generic;
using GC.Models;

namespace GC.Data
{
    public interface IProductRepo 
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct();
    }
}