using System;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentTask.Core
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithVat
        {
            get
            {
                return Price *= 1.125M;
            }
        }
    }
}
