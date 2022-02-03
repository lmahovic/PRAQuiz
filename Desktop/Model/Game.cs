using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Model
{
   public class Game
    {
        public Game()
        {

        }
        public Game(int quiz_id, string gamepin)
        {
            QuizID = quiz_id;
            GamePIN = gamepin;
            DatePlayed = DateTime.Now;
        }

        public Game(int quiz_id, string gamepin, DateTime dateplayed, int base_id)
        {
            ID = base_id;
            QuizID = quiz_id;
            GamePIN = gamepin;
            DatePlayed = dateplayed;
        }



        public  DateTime DatePlayed { get; }
        public readonly int QuizID;
        public readonly string GamePIN;
        public int ID { get; set; }

        public override int GetHashCode() => ID.GetHashCode();

        public override bool Equals(object obj) => obj is Game g ? g.ID == ID : false;

        public override string ToString() => $"Game:{ID} {QuizID} {DatePlayed} {GamePIN}";
    
}
}
