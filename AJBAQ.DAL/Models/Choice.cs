using System;
using System.Collections.Generic;

namespace AJBAQ.DAL.Models
{
    public partial class Choice
    {
        public Choice()
        {
            Answer = new HashSet<Answer>();
        }

        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
        public bool IsRightChoice { get; set; }
        public string Choice1 { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
    }
}
