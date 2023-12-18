using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class ProductController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Product> products = await GetProducts();


            return View(products);
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> product = new List<Product>();

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/products");

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();

                    Product singleProduct = JsonConvert.DeserializeObject<Product>(jsonContent);
                    product.Add(singleProduct);
                }
                return product;
            }
        }
    }

}
