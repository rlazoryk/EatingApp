using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatingApp.Core.Models
{
    public class ProductType: IEntity<int>
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public string Name { get; set; }
    }
}
