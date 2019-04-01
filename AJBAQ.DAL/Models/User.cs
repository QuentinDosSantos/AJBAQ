using System;
using System.Collections.Generic;

namespace AJBAQ.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Answer = new HashSet<Answer>();
        }

        public string UserId { get; set; }
        public string Username { get; set; }
        public string Userpass { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
    }
}
