using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsStore.Models
{
    public class UserClient
    {
        public Guid ID { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 4)]
        public string LastName { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 4)]
        public string UserName { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
