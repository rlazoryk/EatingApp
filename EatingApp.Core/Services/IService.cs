using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.Core.Services
{
    public interface IService<TEntityDTO>
    {
        List<TEntityDTO> GetAll();

        TEntityDTO GetById(int id);
        TEntityDTO Insert(TEntityDTO entity);
        TEntityDTO Update(TEntityDTO entity);
        void Delete(int Id);
    }
}
