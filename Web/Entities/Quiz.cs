using System;
using System.Collections.Generic;

namespace Web.Entities
{
    public partial class Quiz
    {
        public Quiz()
        {
            Games = new HashSet<Game>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
