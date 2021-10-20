using System.Collections.Generic;
using AutoMapper;
using GC.Data;
using GC.Dtos;
using GC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("gc-api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public IMapper _mapper { get; }

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<User>> GetAllUsers() 
        {
            var users = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpGet("{id}")]
        public ActionResult <UserReadDto> GetUserById(int id) 
        {
            var user = _repository.GetUserById(id);

            if (user == null) 
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<UserReadDto>(user));
        }
    }
}