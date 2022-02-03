using System;
using System.Collections.Generic;

namespace Web.Entities
{
    public partial class PlayerRanking
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TotalPoints { get; set; }
        public int Ranking { get; set; }

        public virtual Player Player { get; set; } = null!;
    }
}
