using ApiProducts.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProducts.Controllers
{
    //[DisableCors]
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        readonly ProductStorage ps = new ProductStorage();
        // GET: api/<ProductsController>
        [HttpGet]
        public List<Product> Get()
        {
            return ps.ReadProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var listProducts= ps.ReadProducts();
            var producto = listProducts.Where(p => p.Id == id).FirstOrDefault();
            return producto;
        }

        // POST api/<ProductsController>
        //[Route("api/[controller]/alta")]
        [HttpPost]
        public List<Product> Post(Product product)
        {
            var listProducts = ps.CrateProduct(product);
            return listProducts;
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public List<Product> Put(Product product)
        {
            var listProducts = ps.ReadProducts();
            foreach (Product prod in listProducts)
            {
                if(prod.Id == product.Id)
                {
                    prod.Name = product.Name;
                    prod.Description = product.Description;
                    prod.CategoryType = product.CategoryType;
                    prod.Price = product.Price;
                    prod.Quantity = product.Quantity;
                }
            }
            return listProducts;
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public List<Product> Delete(int id)
        {
            var listProducts = ps.ReadProducts();
            listProducts.RemoveAll(p => p.Id == id);
            return listProducts;
        }
    }
}
