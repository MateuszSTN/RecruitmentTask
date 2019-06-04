using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecruitmentTask.Data;
using RecruitmentTask.Mvc.ViewModels;

namespace RecruitmentTask.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var productsViewModel = new ProductsViewModel()
            {
                Products = (await _productRepository.GetAll()).ToList(),
                Title = "All products"
            };
            return View(productsViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
