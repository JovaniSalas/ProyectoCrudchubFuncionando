using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProducts.Models
{
    public interface IProductStorage
    {
        List<Product> ReadProducts();

        List<Product> CrateProduct(Product product);
    }
}
