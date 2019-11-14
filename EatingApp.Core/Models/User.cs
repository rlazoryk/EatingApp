using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatingApp.Core.Models
{
    public class User: IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public string Name => $"{FirstName} {LastName}";
        
        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }
        
        public List<Order> Orders { get; set; }
    }
}
