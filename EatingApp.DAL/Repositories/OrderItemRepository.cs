using EatingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EatingApp.Core.Abstractions.Repositories;

namespace EatingApp.DAL.Repositories
{
    public class OrderItemRepository: Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(FoodApiContext context): base(context)
        {
        }
    }
}
