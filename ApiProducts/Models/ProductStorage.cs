using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProducts.Models
{
    /** 
     * actuara como nuestra BD
     */
    public class ProductStorage: IProductStorage
    {
        public List<Product> listProducts = new List<Product>();
        public ProductStorage()
        {
            if (listProducts.Count == 0)
            {
                listProducts.Add(new Product() { Id = 1, Name = "Aspirina", Description = "sirve para  aliviar los dolores de cabeza y corporales", CategoryType = "Salud", Price = 25, Quantity = 50 });
                listProducts.Add(new Product() { Id = 2, Name = "Termómetro", Description = "instrumento de medición de temperatura", CategoryType = "Salud", Price = 50, Quantity = 25 });
                listProducts.Add(new Product() { Id = 3, Name = "Cubrebocas Desechables", Description = "Cubrebocas desechable, Sujetador de resorte reforzado para use rudo", CategoryType = "Salud", Price = 13, Quantity = 100 });
                listProducts.Add(new Product() { Id = 4, Name = "Suero electrolit", Description = "Suero rehidratante Electrolit sabor manzana 625 ml", CategoryType = "Salud", Price = 27, Quantity = 12 });
                listProducts.Add(new Product() { Id = 5, Name = "Pan Tostado", Description = "Pan tostado Clasico", CategoryType = "Comida", Price = 18, Quantity = 22 });
                listProducts.Add(new Product() { Id = 6, Name = "Yogurt Griego", Description = "Yogurt Griego Natural sin Azucar", CategoryType = "Comida", Price = 18, Quantity = 15 });
            }
        }

        public List<Product> ReadProducts()
        {
            return listProducts;
        }

        public List<Product> CrateProduct(Product product)
        {
            bool insertCorrect = true;
            try
            {
                var idMax = listProducts.Max(p => p.Id);
                product.Id = idMax+1;
                listProducts.Add(product);
            }
            catch (Exception)
            {
                insertCorrect = false;
            }
            if(insertCorrect == true)
            {
                return ReadProducts();
            }
            return new List<Product>();
        }


    }
}
