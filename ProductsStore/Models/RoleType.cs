using System;
using System.Collections.Generic;

namespace ProductsStore.Models
{
    public class RoleType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<UserClient> UserClients { get; set; }
        public RoleType()
        {
            CreatedDate = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
