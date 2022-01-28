using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProductsStore.Models
{
    public class TypeProduct
    {
        public Guid ID { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string TypeName { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
