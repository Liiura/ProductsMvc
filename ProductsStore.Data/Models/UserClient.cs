using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsStore.Data.Models
{
    public class UserClient
    {
        public Guid Id { get; set; }
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

        [ForeignKey("RoleType")]
        public Guid RoleTypeId { get; set; }
        public virtual RoleType RoleType { get; set; }

        public UserClient()
        {
            CreatedDate = DateTime.Now;
            Id = Guid.NewGuid();
        }

    }
}
