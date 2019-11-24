using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitmentTask.Core;
using RecruitmentTask.Data;

namespace RecruitmentTask.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        [BindProperty]
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public CreateModel(IProductRepository productRepository, IHtmlHelper htmlHelper)
        {
            _productRepository = productRepository;
            Categories = htmlHelper.GetEnumSelectList<Category>();
        }

        public async Task<IActionResult> OnGet(int productId)
        {
            
            Product = await _productRepository.GetById(productId);
            if(Product == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _productRepository.Create(Product);
            TempData["Message"] = $"Product successfully created! New product id {Product.Id} ";
            return RedirectToPage("./Products");            
        }
    }
}