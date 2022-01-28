using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsStore.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        [ForeignKey("TypeId")]
        public virtual Type Type { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public bool IsActive { get; set; }

    }
}
