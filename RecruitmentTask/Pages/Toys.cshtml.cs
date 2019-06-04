using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecruitmentTask.Core;
using RecruitmentTask.Data;

namespace RecruitmentTask.Pages
{
    public class ToysModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IEnumerable<Product> Toys { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ToysModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task OnGet()
        {
            Toys = await _productRepository.GetAll(SearchTerm, Category.Toy);
        }
    }
}