using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GC.Dtos;
using GC.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace GC.Data
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly GCContext _context;
        private readonly IMapper _mapper;

        public SqlProductRepo(GCContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
        public void UpdateProduct() 
        {
            // Done by automapper
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}