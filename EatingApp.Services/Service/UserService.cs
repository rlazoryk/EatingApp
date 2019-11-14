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
    public class UserService: IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Delete(int Id)
        {
            var user = _unitOfWork.UserRepository.GetById(Id);
            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.SaveChanges();
        }

        public List<UserDTO> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll().Select(item => _mapper.Map(item, new UserDTO())).ToList();
        }

        public UserDTO GetById(int id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);
            return _mapper.Map(user, new UserDTO());
        }

        public UserDTO Insert(UserDTO userDTO)
        {
            var user = _mapper.Map(userDTO, new User());
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.SaveChanges();
            userDTO.Id = user.Id;
            return userDTO;
        }

        public UserDTO Update(UserDTO user)
        {
            var oldValue = new User();
            _mapper.Map(user, oldValue);
            _unitOfWork.UserRepository.Update(oldValue);
            _unitOfWork.SaveChanges();
            return user;
        }
    }
}
