using EatingApp.Core.Abstractions.Repositories;
using EatingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.DAL.Repositories
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(FoodApiContext context) : base(context)
        {
        }
    }
}
