using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RecruitmentTask.Core;
using RecruitmentTask.Data;

namespace RecruitmentTask.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Product> Products { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ProductsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task OnGet()
        {
            Products = await _productRepository.GetAll(SearchTerm);
        }

        // TODO: Think about add a Details Page
    }
}