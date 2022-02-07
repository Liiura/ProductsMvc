using System.ComponentModel.DataAnnotations;

namespace ProductsStore.Areas.Admin.Data
{
    public class CreateProductEditViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public double Value { get; set; }

        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string TypeId { get; set; }
    }
}
