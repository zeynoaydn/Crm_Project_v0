﻿using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;
        private readonly IProductsDal _productsDal;

        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService, IMapper mapper, IProductsDal productsDal)
        {
            _logger = logger;
            _productsService = productsService;
            _mapper = mapper;
            _productsDal = productsDal;

        }
        public IActionResult Index()
        {
            var result = _productsService.GetAll();
            var productsDtos = _mapper.Map<List<ProductsDto>>(result.Data);
            return View(productsDtos);
        }

        [HttpPost]
        public List<ProductsDto> GetProducts()
        {
            var result = _productsService.GetAll();
            //return result.Data;
            var productsDtos = _mapper.Map<List<ProductsDto>>(result.Data);
            return productsDtos;
        }

        [HttpPost]
        public IDataResult<ProductsDto> GetById(int productId)
        {
            var result = _productsService.GetById(productId);
            var productsDtos = _mapper.Map<ProductsDto>(result.Data);
            if (productsDtos != null)
            {
                return new SuccessDataResult<ProductsDto>(productsDtos);
            }
            return new ErrorDataResult<ProductsDto>(productsDtos, "Veri Bulunamadı!");
        }
        public IActionResult Add()
        {
            ViewBag.Products = _productsService.GetAll();
            return View();
        }
        [HttpPost]
        public IDataResult<ProductsDto> Add(ProductsDto productsDto)
        {

            ProductsDto addProducts = new ProductsDto()
            {
                Name = productsDto.Name,
                NumberOfProduct = productsDto.NumberOfProduct,
                Price = productsDto.Price,
                Description = productsDto.Description,
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                IsActive = true,
                IsDeleted = false,
            };
            var productsDtos = _mapper.Map<Products>(addProducts);

            var result = _productsService.Add(productsDtos);
            if (result.Success)
            {
                return new SuccessDataResult<ProductsDto>(result.Message);
            }
            return new ErrorDataResult<ProductsDto>(result.Message);
        }

        [HttpPost]
        public IDataResult<ProductsDto> Delete(Products products)
        {
            var result = _productsService.Delete(products);
            if (result.Success)
            {
                return new SuccessDataResult<ProductsDto>(result.Message);
            }
            return new ErrorDataResult<ProductsDto>(result.Message);

        }

        [HttpPost]
        public IDataResult<ProductsDto> Update(ProductsDto products)
        {
            var result = new Products()
            {
                Id = products.Id,
                Name = products.Name,
                NumberOfProduct = products.NumberOfProduct,
                Price = products.Price,
                Description = products.Description,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                UpdatedId = 1,
                IsActive = true,
                IsDeleted = false,
            };

            var deneme = _productsService.Update(result);
            if (deneme.Success)
            {
                return new SuccessDataResult<ProductsDto>(deneme.Message);
            }
            return new ErrorDataResult<ProductsDto>(deneme.Message);
        }


        //[HttpPost]
        //public IActionResult Update(int id, ProductsDto productsDto)
        //{ 
        //var productsUpdate=_productsDal.Get(p=>p.Id == products.Id);

        //productsUpdate.Name = products.Name;
        //productsUpdate.NumberOfProduct = products.NumberOfProduct;
        //productsUpdate.Price = products.Price;
        //productsUpdate.Description = products.Description;
        //productsUpdate.CreatedDate = products.CreatedDate;
        //productsUpdate.CreatedUserId = products.CreatedUserId;
        //productsUpdate.IsActive = products.IsActive;
        //productsUpdate.IsDeleted = products.IsDeleted;

        //_productsDal.Update(productsUpdate);
        //return new SuccessDataResult<ProductsDto>();
        //var result = _productsService.Update(products);
        //if (result.Success)
        //{
        //    return new SuccessDataResult<ProductsDto>( result.Message);
        //}
        //return new ErrorDataResult<ProductsDto>(result.Message);


        //if (!ModelState.IsValid)
        //{
        //    return new ErrorDataResult<ProductsDto>();
        //}
        //var values=_mapper.Map<ProductsDto>(productsDto);
        //var result= _productsService.Update(values);
        //    //var productId=_productsService.GetById(id);
        //    //ProductsDto updateProducts = new ProductsDto()
        //    //{
        //    //    Name = productsDto.Name,
        //    //    NumberOfProduct = productsDto.NumberOfProduct,
        //    //    Price = productsDto.Price,
        //    //    Description = productsDto.Description,
        //    //    //CreatedDate = DateTime.Now,
        //    //    //CreatedUserId = 1,
        //    //    //IsActive = true,
        //    //    //IsDeleted = false,
        //    //};
        //    //var productsDtos = _mapper.Map<Products>(updateProducts);

        //    //var result = _productsService.Update(productsDto);
        //    //if (result.Success)
        //    //{
        //    //    return new SuccessDataResult<ProductsDto>(result.Message);
        //    //}
        //    //return new ErrorDataResult<ProductsDto>(result.Message);


        //    //var existingProduct = _productsService.GetById(id);

        //    //if (existingProduct == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //existingProduct.Name = productsDto.Name;
        //    //existingProduct.NumberOfProduct = productsDto.NumberOfProduct;
        //    //existingProduct.Price = productsDto.Price;
        //    //existingProduct.Description = productsDto.Description;

        //    //_productsService.Update(existingProduct);

        //    //return RedirectToAction("Index"); 
        //}

        //CustomerRelationshipManagementContext _context = new CustomerRelationshipManagementContext();
        //public ActionResult Update(int id)
        //{
        //    var data = _context.Products.Where(p => p.Id == id).FirstOrDefault();
        //    return View(data);
        //}
        //[HttpPost]
        //public IDataResult<ProductsDto> Update(ProductsDto productsDto)
        //{
        //    var data = _context.Products.Where(p => p.Id == productsDto.Id).FirstOrDefault();
        //    if (data != null)
        //    {
        //        data.Name = productsDto.Name;
        //        data.NumberOfProduct = productsDto.NumberOfProduct;
        //        data.Price = productsDto.Price;
        //        data.Description = productsDto.Description;
        //        _context.SaveChanges();
        //    }
        //    var result = _productsService.Update(productsDto);
        //    return new ErrorDataResult<Products>(result.Message);
        //}
    }
}
