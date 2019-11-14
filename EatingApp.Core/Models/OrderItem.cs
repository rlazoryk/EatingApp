using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace EatingApp.Core.Models
{
    public class OrderItem: IEntity<int>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        /*public OrderItem(Product product, short quantity)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity;
        }*/
        public int ProductId { get; set; }
        public Product Product { get; set; }        

        public short Quantity { get; set; }

        public string Descriprion { get; set; }
    }
}