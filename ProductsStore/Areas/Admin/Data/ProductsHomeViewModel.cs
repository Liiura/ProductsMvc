using System.Collections.Generic;

namespace ProductsStore.Areas.Admin.Data
{
    public class ProductsHomeViewModel
    {
        public string Description { get; set; }
        public string TypeProduct { get; set; }
        public List<ProductsHomeViewModel> ListProducts { get; set; }

        public ProductsHomeViewModel()
        {
            ListProducts = new List<ProductsHomeViewModel>();
        }

    }
}
