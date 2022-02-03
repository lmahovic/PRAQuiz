using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Model
{
   public class Answer
    {

        public Answer()
        {

        }
        public Answer(int question_id, string text,  bool correct)
        {
            questionID = question_id;
            Text = text;
            
            Correct = correct;
        }
        public Answer(string text, int question_id, int base_id, bool correct)
        {
            Text = text;
            questionID = question_id;
            ID = base_id;
            Correct = correct;
        }

        public Answer(string text, bool correct)
        {
            Text = text;
            Correct = correct;
        }

        public Answer(string text)
        {
            Text = text;
        }

        public readonly int questionID;
        public int ID { get; set; }
        public string Text { get; set; }

        public bool Correct { get; set; }

        public override bool Equals(object obj) => obj is Answer a ? a.ID == ID : false;


        public override int GetHashCode() => ID.GetHashCode();

        public override string ToString() => $"ID:{ID} QuestionID: {questionID} Answer: {Text} Correct:{Correct.ToString()}";

    }
}

