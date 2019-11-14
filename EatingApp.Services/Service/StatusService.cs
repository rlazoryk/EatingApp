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
    public class StatusService: IStatusService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public StatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Delete(int Id)
        {
            var statusType = _unitOfWork.StatusRepository.GetById(Id);
            _unitOfWork.StatusRepository.Delete(statusType);
            _unitOfWork.SaveChanges();
        }

        public List<StatusDTO> GetAll()
        {
            return _unitOfWork.StatusRepository.GetAll().Select(item => _mapper.Map(item, new StatusDTO())).ToList();
        }

        public StatusDTO GetById(int id)
        {
            var order = _unitOfWork.StatusRepository.GetById(id);
            return _mapper.Map(order, new StatusDTO());
        }

        public StatusDTO Insert(StatusDTO statusDTO)
        {
            var status = _mapper.Map(statusDTO, new Status());
            _unitOfWork.StatusRepository.Add(status);
            _unitOfWork.SaveChanges();
            statusDTO.Id = status.Id;
            return statusDTO;
        }

        public StatusDTO Update(StatusDTO status)
        {
            var oldValue = new Status();
            _mapper.Map(status, oldValue);
            _unitOfWork.StatusRepository.Update(oldValue);
            _unitOfWork.SaveChanges();
            return status;
        }
    }
}
