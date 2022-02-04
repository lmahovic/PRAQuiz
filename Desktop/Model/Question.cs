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
            QuestionText = text;
            QuizID = quiz_id;
            TimeLimit = answertimelimit;
        }
        public Question(string text, int quiz_id, int answertimelimit, int base_id)
        {
            QuestionText = text;
            QuizID = quiz_id;
            ID = base_id;
            TimeLimit = answertimelimit;
        }

        public Question( ISet<Answer> answers, int quizID, int iD, string text, int answerTimeLimit)
        {
            Answers = answers;
            QuizID = quizID;
            ID = iD;
            QuestionText = text;
            TimeLimit = answerTimeLimit;
        }

        public ISet<Answer> Answers { get; set; }
        public readonly int QuizID;

        public int ID { get; set; }

        public string QuestionText { get; set; }

        public int TimeLimit { get; set; }

        public override bool Equals(object obj) => obj is Question q ? q.ID == ID : false;

        public override int GetHashCode() => ID.GetHashCode();

        public override string ToString() => $"{ID} {QuestionText} {QuizID} {TimeLimit}";
    }
}
