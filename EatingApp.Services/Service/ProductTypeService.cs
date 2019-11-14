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
    public class ProductTypeService: IProductTypeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Delete(int Id)
        {
            var productType = _unitOfWork.ProductTypeRepository.GetById(Id);
            _unitOfWork.ProductTypeRepository.Delete(productType);
            _unitOfWork.SaveChanges();
        }

        public List<ProductTypeDTO> GetAll()
        {
            return _unitOfWork.ProductTypeRepository.GetAll().Select(item => _mapper.Map(item, new ProductTypeDTO())).ToList();
        }

        public ProductTypeDTO GetById(int id)
        {
            var order = _unitOfWork.ProductTypeRepository.GetById(id);
            return _mapper.Map(order, new ProductTypeDTO());
        }

        public ProductTypeDTO Insert(ProductTypeDTO productTypeDTO)
        {
            var productType = _mapper.Map(productTypeDTO, new ProductType());
            _unitOfWork.ProductTypeRepository.Add(productType);
            _unitOfWork.SaveChanges();
            productTypeDTO.Id = productType.Id;
            return productTypeDTO;
        }

        public ProductTypeDTO Update(ProductTypeDTO productType)
        {
            var oldValue = new ProductType();
            _mapper.Map(productType, oldValue);
            _unitOfWork.ProductTypeRepository.Update(oldValue);
            _unitOfWork.SaveChanges();
            return productType;
        }
    }
}
