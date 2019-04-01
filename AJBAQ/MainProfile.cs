using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJBAQ
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<DAL.Models.Answer, DTO.Answer>();
            CreateMap<DAL.Models.Choice, DTO.Choice>().ForMember(c => c.Question, opt => opt.Ignore());
            CreateMap<DAL.Models.Question, DTO.Question>();
            CreateMap<DAL.Models.User, DTO.User>();
        }
    }
}
