using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.Core.Models
{
    public class Status : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Order> Orders { get; set; }
    }
}
