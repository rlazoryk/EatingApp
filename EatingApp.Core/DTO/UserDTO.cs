using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.Core.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }        
    }
}
