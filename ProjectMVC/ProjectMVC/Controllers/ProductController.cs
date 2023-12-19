using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging;
using ProjectMVC.Models;
using System.Collections.Immutable;
using System.Net.NetworkInformation;

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
            //List<ProductResponse> product = new List<ProductResponse>();
            //  List<ProductList> p = new List<ProductList>();
            List<Product> product = new List<Product>();


            //   List<Product> productList;
            //  Products product;

            using (HttpClient client = new HttpClient())
            {
                //   client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/products");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    //  Product product = JsonConvert.DeserializeObject<Product>(jsonContent);
                    ProductList productlist = JsonConvert.DeserializeObject<ProductList>(jsonContent);
                    //foreach (var products in productlist.Products)
                    //{
                    // // p.Add(productlist.Products);
                    //    Console.WriteLine($"Product ID: {products.id}");

                    //    Console.WriteLine($"Title: {products.title}");

                    //    Console.WriteLine($"Description: {products.description}");
                    //    Console.WriteLine($"Price: ${products.price}");

                    //    foreach (var products in productlist.Products)
                    //        //{
                    //        //    //Console.WriteLine($"Product ID: {product.id}");
                    //        //    //Console.WriteLine($"Title: {product.title}");
                    //        //    //Console.WriteLine($"Description: {product.description}");
                    //        //    Console.WriteLine($"Price: ${products.price}");

                    //        product.Add(products);
                    //    //}




                    //    //}

                    //    //  var p=productlist.Products.ToList();
                    //    // product = productlist.Products;
                    //    //  product.Add(p);
                    //}
                    productlist.Products.ForEach(products => product.Add(products));


                 
                }
                return product;

            }
                }
        [HttpPost]
        public IActionResult AddToFavourites(Product product)
        {
          //  productlist.Add(product);
            return RedirectToAction("Index");
        }


    }
}
