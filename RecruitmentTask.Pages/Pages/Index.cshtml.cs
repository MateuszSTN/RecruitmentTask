using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RecruitmentTask.Core;
using RecruitmentTask.Data;

namespace RecruitmentTask.Pages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<IndexModel> _logger;

        public string Message { get; set; }
        public IEnumerable<Product> Products { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(IConfiguration config,
                         IProductRepository productRepository,
                         ILogger<IndexModel> logger)
        {
            _config = config;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task OnGet()
        {
            _logger.LogError("Executing IndexModel");
            Message = _config["Message"];
            Products = await _productRepository.GetAll();
        }
    }
}