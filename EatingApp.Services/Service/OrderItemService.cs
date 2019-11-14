using AutoMapper;
using EatingApp.Core.Abstractions;
using EatingApp.Core.DTO;
using EatingApp.Core.Models;
using EatingApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EatingApp.Services.Service
{
    public class OrderItemService: IOrderItemService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Delete(int Id)
        {
            var order = _unitOfWork.OrderItemRepository.GetById(Id);
            _unitOfWork.OrderItemRepository.Delete(order);
            _unitOfWork.SaveChanges();
        }

        public List<OrderItemDTO> GetAll()
        {
            return _unitOfWork.OrderItemRepository.GetAll().Select(item => _mapper.Map(item, new OrderItemDTO())).ToList();
        }

        public OrderItemDTO GetById(int Id)
        {
            var order = _unitOfWork.OrderItemRepository.GetById(Id);
            return _mapper.Map(order, new OrderItemDTO());
        }

        public OrderItemDTO Insert(OrderItemDTO orderItemDTO)
        {
            var orderItem = _mapper.Map(orderItemDTO, new OrderItem());
            _unitOfWork.OrderItemRepository.Add(orderItem);
            _unitOfWork.SaveChanges();
            orderItemDTO.Id = orderItem.Id;
            return orderItemDTO;
        }

        public OrderItemDTO Update(OrderItemDTO orderItemDTO)
        {
            var oldValue = _mapper.Map(orderItemDTO, new OrderItem());
            _unitOfWork.OrderItemRepository.Update(oldValue);
            _unitOfWork.SaveChanges();
            return orderItemDTO;
        }
    }
}
