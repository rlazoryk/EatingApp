using EatingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatingApp.DAL;
using EatingApp.Core.Services;
using AutoMapper;
using EatingApp.Core.Abstractions;
using EatingApp.Core.DTO;

namespace EatingApp.Services
{
    public class OrderService: IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Delete(int Id)
        {
            var order =_unitOfWork.OrderRepository.GetById(Id);
            _unitOfWork.OrderRepository.Delete(order);
            _unitOfWork.SaveChanges();
        }

        public List<OrderDTO> GetAll()
        {
            return _unitOfWork.OrderRepository.GetAll().Select(item => _mapper.Map(item, new OrderDTO())).ToList();
        }

        public OrderDTO GetById(int id)
        {
            var order = _unitOfWork.OrderRepository.GetById(id);            
            return _mapper.Map(order, new OrderDTO());
        }

        public OrderDTO Insert(OrderDTO orderDTO)
        {
            var order = _mapper.Map(orderDTO, new Order());
            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.SaveChanges();
            orderDTO.Id = order.Id;
            return orderDTO;
        }

        public OrderDTO Update(OrderDTO order)
        {
            var oldValue = new Order();
            _mapper.Map(order, oldValue);                       
            _unitOfWork.OrderRepository.Update(oldValue);
            _unitOfWork.SaveChanges();
            return order;
        }
    }
}
