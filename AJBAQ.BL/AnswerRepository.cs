using AJBAQ.DAL;
using AJBAQ.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJBAQ.BL
{
    public class AnswerRepository
    {
        private IMapper _mapper;

        public AnswerRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Answer(Answer answer)
        {
            using (AJBAQContext context = new AJBAQContext())
            {
                answer.AnswerTime = DateTime.Now;
                context.Add(_mapper.Map<DAL.Models.Answer>(answer));
                context.SaveChanges();
            }
        }

        public List<Answer> GetAnswersByUsers(string userId)
        {
            using (AJBAQContext context = new AJBAQContext())
            {
                return _mapper.Map<List<Answer>>(context.Answer.Where(a => a.UserId == userId).ToList());
            }
        }
    }
}
