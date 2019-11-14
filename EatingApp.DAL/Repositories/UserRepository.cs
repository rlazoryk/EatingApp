using System;
using System.Collections.Generic;
using System.Text;
using EatingApp.Core.Models;
using EatingApp.Core.Abstractions.Repositories;


namespace EatingApp.DAL.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(FoodApiContext context) : base(context)
        {
        }
    }
}
