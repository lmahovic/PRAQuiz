using System;
using System.Collections.Generic;

namespace Web.Entities
{
    public partial class Answer
    {
        public Answer()
        {
            PlayerQuestionAnswers = new HashSet<PlayerQuestionAnswer>();
        }

        public int Id { get; set; }
        public string AnswerText { get; set; } = null!;
        public bool Correct { get; set; }
        public int QuestionId { get; set; }
        public byte AnswerOrder { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual ICollection<PlayerQuestionAnswer> PlayerQuestionAnswers { get; set; }
    }
}
