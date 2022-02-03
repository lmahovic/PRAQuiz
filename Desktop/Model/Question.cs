using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Model
{
    public class Question
    {
        public Question()
        {

        }
        public Question(string text, int quiz_id, int answertimelimit)
        {
            Text = text;
            QuizID = quiz_id;
            AnswerTimeLimit = answertimelimit;
        }
        public Question(string text, int quiz_id, int answertimelimit, int base_id)
        {
            Text = text;
            QuizID = quiz_id;
            ID = base_id;
            AnswerTimeLimit = answertimelimit;
        }

        public Question(ISet<Answer> answers, int quizID, int iD, string text, int answerTimeLimit)
        {
            Answers = answers;
            QuizID = quizID;
            ID = iD;
            Text = text;
            AnswerTimeLimit = answerTimeLimit;
        }

        public ISet<Answer> Answers { get; set; }
        public readonly int QuizID;

        public int ID { get; set; }

        public string Text { get; set; }

        public int AnswerTimeLimit { get; set; }

        public override bool Equals(object obj) => obj is Question q ? q.ID == ID : false;

        public override int GetHashCode() => ID.GetHashCode();

        public override string ToString() => $"{ID} {Text} {QuizID} {AnswerTimeLimit}";
    }
}
