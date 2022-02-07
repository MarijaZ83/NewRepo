using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication.Models;
using SEDCWebApplication.Models.Interfaces;
using SEDCWebApplication.ViewModels;

namespace SEDCWebApplication.Controllers
{
    [Route("Products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        //private readonly List<Product> products;
        public ProductController (IProductRepository productRepository, IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            _hostingEnvironment = hostingEnvironment;
            //products = _productRepository.GetAllProducts().ToList();
        }

        [Route("List")]
        
        public IActionResult List()
        {
            List<Product> products = _productRepository.GetAllProducts().ToList();
            ViewBag.Title = "Pizza";

            return View(products);
        }

        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            Product product = _productRepository.GetProductById(id);

            ProductDetailsViewModel productVM = new ProductDetailsViewModel();
            productVM.ProductId = product.Id;
            productVM.Name = product.ProductName;
            productVM.UnitPrice = product.UnitPrice;
            productVM.DiscountedPrice = product.DiscountedPrice;
            productVM.Description = product.Description;
            productVM.IsDiscounted = product.IsDiscounted;
            productVM.Picture = product.Picture;


            return View(productVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create (ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = "mini.jpg";
                if(model.Picture != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Picture.CopyTo(new FileStream(filePath, FileMode.Create));

                }

                Product product = new Product
                {
                    ProductName = model.Name,
                    UnitPrice = model.UnitPrice,
                    DiscountedPrice = model.DiscountedPrice,
                    Description = model.Description,
                    IsActive = model.IsActive,
                    IsDeleted = model.IsDeleted,
                    ImagePath = "~/images/" + uniqueFileName
                };

                Product newProduct = _productRepository.Add(product);
                 return RedirectToAction("List", new { id = newProduct.Id });
            } 
            else
            {
                return View();
            }
        }

        //Edit
        [HttpGet]
        [Route("Update/{id}")]
        public IActionResult Update(int id)
        {
            Product product = _productRepository.GetProductById(id);
            ProductUpdateViewModel productUpdateViewModel = new ProductUpdateViewModel
            {
                Name = product.ProductName,
                UnitPrice = product.UnitPrice,
                DiscountedPrice = product.DiscountedPrice,
                Description = product.Description,
            };
            return View(productUpdateViewModel);
        }

        [HttpPost]
        [Route("Update/{id}")]

        public IActionResult Update(int id, ProductUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = _productRepository.GetProductById(id);
                product.ProductName = model.Name;
                product.UnitPrice = model.UnitPrice;
                product.DiscountedPrice = model.DiscountedPrice;
                product.Description = model.Description;
                product.IsActive = model.IsActive;
                product.IsDeleted = model.IsDeleted;

                string uniqueFileName = "mini.jpg";
                if (model.Picture != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                product.ImagePath = "~/images/" + uniqueFileName;
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

    }
}
