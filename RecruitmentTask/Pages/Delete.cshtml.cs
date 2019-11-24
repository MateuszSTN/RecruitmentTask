using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitmentTask.Core;
using RecruitmentTask.Data;

namespace RecruitmentTask.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        [BindProperty]
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public DeleteModel(IProductRepository productRepository, IHtmlHelper htmlHelper)
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

        public async Task<IActionResult> OnPost(int productId)
        {
            var removeProduct = await _productRepository.GetById(productId);
            if(removeProduct != null)
            {
                await _productRepository.Delete(removeProduct);
            }
            TempData["Message"] = $"Product with id {productId} successfully removed!";
            return RedirectToPage("./Products");            
        }
    }
}