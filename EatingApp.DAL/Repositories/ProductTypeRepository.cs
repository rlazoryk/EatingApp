using EatingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EatingApp.Core.Abstractions.Repositories;


namespace EatingApp.DAL.Repositories
{
    public class ProductTypeRepository: Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(FoodApiContext context): base(context)
        {
        }
    }
}
