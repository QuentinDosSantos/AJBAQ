using System;
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
    public class AnswerController : ControllerBase
    {
        IMapper _mapper;
        public AnswerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // POST: api/Answer
        [HttpPost]
        public void Post([FromBody] Answer value)
        {
            AnswerRepository repository = new AnswerRepository(_mapper);
            repository.Answer(value);
        }
    }
}
