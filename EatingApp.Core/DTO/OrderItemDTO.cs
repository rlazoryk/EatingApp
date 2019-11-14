using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.Core.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public string Descriprion { get; set; }
    }
}
