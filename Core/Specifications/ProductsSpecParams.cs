using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsSpecParams
    {
        private string search;

        public string Search { 
            get => search;
            set{
            search = value.ToLower();
        }
        }
        public string Sort { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public int? PageSize { get; set; } = 6;
        public int? PageIndex { get; set; } = 1;
    }
}