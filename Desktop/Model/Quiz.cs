using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Model
{
    public class Quiz
    {
        public Quiz()
        {

        }
        public Quiz(string title, int autor_id)
        {
            Title = title;
        
            AutorID = autor_id;
        }

        public Quiz(int id, string title, int autor_id)
        {
            ID = id;
            Title = title;

            AutorID = autor_id;
        }



        public Quiz(ISet<Question> questions, string title, int id)
        {
            Questions = questions;
            Title = title;
            ID = id;
        }

        public Quiz(string title, int autor_id, int id) : this(title, autor_id)
        {
        }

        public ISet<Question> Questions { get; set; }
        public int ID { get; set; }

        public readonly int AutorID;
        public string Title { get; set; }
        public int TimesPlayed { get; set; }

        //public override bool Equals(object obj) => obj is Quiz q ? q.ID == ID : false;

        public override int GetHashCode() => ID.GetHashCode();

        public override string ToString() => $"ID{ID} Title:{Title}";
    }
}
