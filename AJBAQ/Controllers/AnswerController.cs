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

        // GET: api/Answer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Answer/5
        [HttpGet("{id}", Name = "GetAnswer")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Answer
        [HttpPost]
        public void Post([FromBody] Answer value)
        {
            AnswerRepository repository = new AnswerRepository(_mapper);
            repository.Answer(value);
        }

        // PUT: api/Answer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
