using System;
using System.Collections.Generic;
using System.Text;
using EatingApp.Core.Models;
using EatingApp.Core.Abstractions.Repositories;


namespace EatingApp.DAL.Repositories
{
    public class StatusRepository: Repository<Status>, IStatusRepository
    {
        public StatusRepository(FoodApiContext context) : base(context)
        {
        }
    }
}
