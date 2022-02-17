using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsStore.Data.Models
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Description { get; set; }
        public double Value { get; set; }
        public bool IsActive { get; set; }
        public Guid TypeId { get; set; }
        public virtual TypeProduct Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public Product()
        {
            CreatedDate = DateTime.Now;
            ID = Guid.NewGuid();
        }
    }
}
