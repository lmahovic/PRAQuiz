using System;
using System.Collections.Generic;

namespace Web.Entities
{
    public partial class Player
    {
        public Player()
        {
            PlayerQuestionAnswers = new HashSet<PlayerQuestionAnswer>();
        }

        public int Id { get; set; }
        public string Nickname { get; set; } = null!;
        public int GameId { get; set; }
        public bool HasQuit { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual PlayerRanking PlayerRanking { get; set; } = null!;
        public virtual ICollection<PlayerQuestionAnswer> PlayerQuestionAnswers { get; set; }
    }
}
