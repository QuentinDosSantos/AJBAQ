using System;
using System.Collections.Generic;

namespace AJBAQ.DTO
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
        public DateTime AnswerTime { get; set; }

        public virtual Choice Choice { get; set; }
        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}
