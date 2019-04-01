using System;
using System.Collections.Generic;

namespace AJBAQ.DAL.Models
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
            Choice = new HashSet<Choice>();
        }

        public int QuestionId { get; set; }
        public string Question1 { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<Choice> Choice { get; set; }
    }
}
