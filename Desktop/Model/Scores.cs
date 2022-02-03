using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Model
{
    public class Scores
    {
        public Scores()
        {

        }
        public Scores(int player_id, int game_id)
        {
            GameID = game_id;
            PlayerID = player_id;
            QuestionsPlayed = 0;
            Accuracy = 0;
            Score = 0;
        }

        public Scores(int base_id, int player_id, int game_id, int questions_played, int accuracy, int score)
        {
            ID = base_id;
            PlayerID = player_id;
            GameID = game_id;
            QuestionsPlayed = questions_played;
            Accuracy = accuracy;
            Score = score;
        }

        public int ID { get; set; }
        public int Score { get; set; }

        public readonly int PlayerID;
        public readonly int GameID;
        public int Accuracy { get; set; }

        public int QuestionsPlayed { get; set; }

        public override bool Equals(object obj) => obj is Scores s ? s.ID == ID : false;


        public override int GetHashCode() => ID.GetHashCode();

        public override string ToString() => $"ID: {ID} PlayerID: {PlayerID} GameID: {GameID} Questions: {QuestionsPlayed} Acc: {Accuracy} Score: {Score}";
    }
}
