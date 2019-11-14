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
    public class ProductService: IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Delete(int Id)
        {
            var product = _unitOfWork.ProductRepository.GetById(Id);
            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.SaveChanges();
        }

        public List<ProductDTO> GetAll()
        {
            return _unitOfWork.ProductRepository.GetAll().Select(item => _mapper.Map(item, new ProductDTO())).ToList();
        }

        public ProductDTO GetById(int id)
        {
            var order = _unitOfWork.ProductRepository.GetById(id);
            return _mapper.Map(order, new ProductDTO());
        }

        public ProductDTO Insert(ProductDTO productDTO)
        {
            var product = _mapper.Map(productDTO, new Product());
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.SaveChanges();
            productDTO.Id = product.Id;
            return productDTO;
        }

        public ProductDTO Update(ProductDTO product)
        {
            var oldValue = new Product();
            _mapper.Map(product, oldValue);
            _unitOfWork.ProductRepository.Update(oldValue);
            _unitOfWork.SaveChanges();
            return product;
        }
    }
}
