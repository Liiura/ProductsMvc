using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsStore.Presentation.AdminViewModels
{
    public class EditProductEditViewModel
    {
        [Display(Name = "Identification")]
        public Guid ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Required]
        [Display(Name = "Type Product")]
        public Guid TypeId { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public string TypeName { get; set; }
    }
}
