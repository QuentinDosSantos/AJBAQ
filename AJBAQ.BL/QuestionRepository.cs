using AJBAQ.DAL;
using AJBAQ.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJBAQ.BL
{
    public class QuestionRepository
    {
        IMapper _mapper;
        public QuestionRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Question GetQuestion(int id)
        {
            using (AJBAQContext context = new AJBAQContext())
            {
                return _mapper.Map<Question>(context.Question.Find(id));
            }
        }

        public List<Question> GetQuestions()
        {
            using (AJBAQContext context = new AJBAQContext())
            {
                return _mapper.Map<List<Question>>(context.Question.Include(q => q.Choice).ToList());
            }
        }

        public Question CreateQuestion(Question question)
        {
            var value = _mapper.Map<DAL.Models.Question>(question);
            using (AJBAQContext context = new AJBAQContext())
            {
                context.Add(value);
                context.SaveChanges();
                return _mapper.Map<Question>(value);
            }
        }
    }
}
