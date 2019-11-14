using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace EatingApp.Core.Models
{
    public class Product: IEntity<int>
    {       
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}