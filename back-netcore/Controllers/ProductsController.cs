using System;
using System.Collections.Generic;
using AutoMapper;
using GC.Data;
using GC.Dtos;
using GC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("gc-api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repository;

        public IMapper _mapper { get; }

        public ProductsController(IProductRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Product>> GetAllProducts() 
        {
            var products = _repository.GetAllProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }
        

    }
}