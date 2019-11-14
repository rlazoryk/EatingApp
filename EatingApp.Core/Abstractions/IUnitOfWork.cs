using EatingApp.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.Core.Abstractions
{
    public interface IUnitOfWork: IDisposable
    {
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        IStatusRepository StatusRepository { get; }
        void SaveChanges();
    }
}
