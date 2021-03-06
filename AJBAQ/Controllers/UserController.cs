﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJBAQ.BL;
using AJBAQ.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AJBAQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "Connect")]
        public ActionResult<User> Connect(string id)
        {
            UserRepository repository = new UserRepository(_mapper);
            return repository.GetUser(id);
        }

        // GET: api/User/5
        [HttpGet("{id}/Answer", Name = "GetAnswerByUser")]
        public ActionResult<object> Answers(string id)
        {
            AnswerRepository repository = new AnswerRepository(_mapper);
            return new { Items = repository.GetAnswersByUsers(id) };
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<User> Post([FromBody] User value)
        {
            UserRepository repository = new UserRepository(_mapper);
            return repository.CreateUser(value);
        }
    }
}
