﻿using Microsoft.AspNetCore.Mvc;
using MyAspNetAppWeb.Helpers;
using MyAspNetAppWeb.Models;

namespace MyAspNetAppWeb.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private IHelper _helper;    

        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context, IHelper helper)
        {
            _productRepository = new ProductRepository();
            _helper = helper;
            _context = context;

        


        }

        public IActionResult Index([FromServices]IHelper helper2)
        {
            var text = "Asp.net";
            var upperText = _helper.Upper(text);
            var status = _helper.Equals(helper2);

            var products = _context.Products.ToList();


            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            
            /*1.yöntem
             * var name = HttpContext.Request.Form["Name"].ToString();
            var price =decimal.Parse( HttpContext.Request.Form["Price"].ToString());
            var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            var color = HttpContext.Request.Form["Color"].ToString();
            
            2.yöntem
            Product  newProduct =new Product() { Name=Name,Price=Price,Color=Color,Stock=Stock};
            */

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            TempData["status"] = "ürün başarıyla eklendi ";


            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product updateProduct,int productId)
        {
            updateProduct.Id= productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            TempData["status"] = "ürün başarıyla güncelledni ";

            
            return RedirectToAction("Index");

        }
    }
}
