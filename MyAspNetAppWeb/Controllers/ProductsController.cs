﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetAppWeb.Helpers;
using MyAspNetAppWeb.Models;
using MyAspNetAppWeb.ViewModels;


namespace MyAspNetAppWeb.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        private readonly IMapper _mapper;
        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _productRepository = new ProductRepository();
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
          
           
            var products = _context.Products.ToList();


            return View(_mapper.Map<List<ProductViewModel>>(products));
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
           

            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay",1},
                { "3 Ay",3},
                { "6 Ay",6},
                { "12 Ay",12}

            };


            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {


                new(){Data="Mavi",Value="Mavi"},
                new(){Data="kırmızı",Value="kırmızı"},
                new(){Data="sarı",Value="sarı"}

            }, "Value", "Data");


            return View();

        }
        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {

           
            if (ModelState.IsValid)
            {  
            _context.Products.Add(_mapper.Map<Product>(newProduct)) ;
            _context.SaveChanges();
            TempData["status"] = "ürün başarıyla eklendi ";


            return RedirectToAction("Index");

            }
            else
            {

                if (!string.IsNullOrEmpty(newProduct.Name) && newProduct.Name.StartsWith("A"))
                {
                    ModelState.AddModelError(String.Empty, "Ürün ismi A harfi başlayamaz");
                }


                ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay",1},
                { "3 Ay",3},
                { "6 Ay",6},
                { "12 Ay",12}

            };


                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {


                new(){Data="Mavi",Value="Mavi"},
                new(){Data="kırmızı",Value="kırmızı"},
                new(){Data="sarı",Value="sarı"}

            }, "Value", "Data");

                return View();
            }
            /*1.yöntem
             * var name = HttpContext.Request.Form["Name"].ToString();
            var price =decimal.Parse( HttpContext.Request.Form["Price"].ToString());
            var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            var color = HttpContext.Request.Form["Color"].ToString();
            
            2.yöntem
            Product  newProduct =new Product() { Name=Name,Price=Price,Color=Color,Stock=Stock};
            */

        

        }
        [HttpGet]

        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.ExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay",1},
                { "3 Ay",3},
                { "6 Ay",6},
                { "12 Ay",12}

            };
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {


                new(){Data="Mavi",Value="Mavi"},
                new(){Data="kırmızı",Value="kırmızı"},
                new(){Data="sarı",Value="sarı"}

            }, "Value", "Data",product.Color);


            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product updateProduct,int productId,string type)
        {
            updateProduct.Id= productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            TempData["status"] = "ürün başarıyla güncelledni ";

            
            return RedirectToAction("Index");

        }

    }
}
