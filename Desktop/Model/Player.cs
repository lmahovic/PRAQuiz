using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Model
{
    public class Player
    {
        public Player()
        {

        }
        public Player(string nickname)
        {
            Nickname = nickname;

        }
        public Player(string nickname, int id)
        {
            Nickname = nickname;
            ID = id;
        }
        public int ID { get; set; }

        public int Score { get; set; }
        public string Nickname { get; set; }

        public override int GetHashCode() => ID.GetHashCode();
        public override bool Equals(object obj) => obj is Player p ? p.ID == ID : false;

        public override string ToString() => $"{ID} {Nickname}";

    }
}
