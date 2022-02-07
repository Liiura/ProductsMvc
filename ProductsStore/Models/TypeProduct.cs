using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProductsStore.Models
{
    public class TypeProduct
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string TypeName { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<Product> Products { get; set; }
        public TypeProduct()
        {
            CreatedDate = DateTime.Now;
            Id = Guid.NewGuid();
            Products = new List<Product>();
        }
    }
}
