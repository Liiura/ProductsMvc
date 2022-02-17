using System;

namespace ProductsStore.Presentation.SharedViewModels
{
    public class SessionModel
    {
        public Guid IdUser { get; set; }
        public string UserName { get; set; }
        public string RoleType { get; set; }
    }
}
