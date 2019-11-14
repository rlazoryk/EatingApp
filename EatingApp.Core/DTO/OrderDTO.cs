using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.Core.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string OrderDescription { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public DateTime? Updated { get; set; }
    }
}
