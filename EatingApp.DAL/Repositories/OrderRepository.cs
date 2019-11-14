using EatingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EatingApp.Core.Abstractions.Repositories;

namespace EatingApp.DAL.Repositories
{
    public class OrderRepository: Repository<Order>, IOrderRepository
    {
        public OrderRepository(FoodApiContext context) : base(context)
        {
        }
    }
}
