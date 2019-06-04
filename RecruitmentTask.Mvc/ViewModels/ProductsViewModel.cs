using RecruitmentTask.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Mvc.ViewModels
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }
        public string Title { get; set; }
    }
}
