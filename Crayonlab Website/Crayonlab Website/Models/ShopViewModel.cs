using System.Collections.Generic;

namespace Crayonlab.Models
{
    public class ShopViewModel
    {
        public List<ShirtType> ShirtTypes { get; set; }
        public Dictionary<int, List<ShirtDesign>> DesignsByType { get; set; }
        public bool IsAdmin { get; set; }
        public List<Partners> Partners { get; set; } // Ensure this property is correctly defined
        public List<NewsandUpdate> NewsandUpdate { get; set; }
    }
}
