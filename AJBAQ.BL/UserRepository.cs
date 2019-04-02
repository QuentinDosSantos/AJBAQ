using AJBAQ.DAL;
using AJBAQ.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AJBAQ.BL
{
    public class UserRepository
    {
        const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
        static Random rd = new Random();

        IMapper _mapper;
        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User CreateUser(User user)
        {
            var value = _mapper.Map<DAL.Models.User>(user);
            using (AJBAQContext context = new AJBAQContext())
            {
                value.UserId = CreateString(5);
                context.Add(value);
                context.SaveChanges();
                return _mapper.Map<User>(value);
            }
        }

        public User GetUser(string id)
        {
            using (AJBAQContext context = new AJBAQContext())
            {
                return _mapper.Map<User>(context.User.Find(id));
            }
        }

        string CreateString(int stringLength)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
