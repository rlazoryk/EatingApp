using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EatingApp.Core.Models
{
    public class Order: IEntity<int>
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }
        
        public DateTime Updated { get; set; }

        public string OrderDescription { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public int UserId { get; set; }

        public User User { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        //public decimal TotalPrice => Items.Sum(t => t.Product.Price * t.Quantity);
    }
}