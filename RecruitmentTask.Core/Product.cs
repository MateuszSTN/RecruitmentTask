using System;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentTask.Core
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
    }
}
