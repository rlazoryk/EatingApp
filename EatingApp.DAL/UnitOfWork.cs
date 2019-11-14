using EatingApp.Core.Abstractions;
using EatingApp.Core.Abstractions.Repositories;
using EatingApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EatingApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private FoodApiContext Context;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IProductRepository _productRepository;
        private IProductTypeRepository _productTypeRepository;
        private IStatusRepository _statusRepository;
        private IUserRepository _userRepository;
        public IOrderRepository OrderRepository 
        { 
            get 
            {
                return _orderRepository ??= new OrderRepository(Context);
            } 
        }
        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                return _orderItemRepository ??= new OrderItemRepository(Context);
            }
        }        

        public IProductRepository ProductRepository 
        { 
            get 
            {
                return _productRepository ??= new ProductRepository(Context);        
            } 
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ??= new UserRepository(Context);
            }
        }

        public IProductTypeRepository ProductTypeRepository
        {
            get
            {
                return _productTypeRepository ??= new ProductTypeRepository(Context);
            }
        }

        public IStatusRepository StatusRepository
        {
            get
            {
                return _statusRepository ??= new StatusRepository(Context);
            }
        }
        public UnitOfWork(FoodApiContext context)
        {
            Context = context;
        }
        public void Dispose()
        {
            if(Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
