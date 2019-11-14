using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.Core.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }        
    }
}
