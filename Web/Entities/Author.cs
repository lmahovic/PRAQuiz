using System;
using System.Collections.Generic;

namespace Web.Entities
{
    public partial class Author
    {
        public Author()
        {
            Quizzes = new HashSet<Quiz>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
