﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AJBAQ.BL;
using AJBAQ.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AJBAQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IMapper _mapper;

        public QuestionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            QuestionRepository repository = new QuestionRepository(_mapper);
            return repository.GetQuestions();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            QuestionRepository repository = new QuestionRepository(_mapper);
            return repository.GetQuestion(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
    }
}