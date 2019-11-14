using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatingApp.Core.Models
{
    interface IEntity<T>
    {
        T Id { get; set; }
    }
}
