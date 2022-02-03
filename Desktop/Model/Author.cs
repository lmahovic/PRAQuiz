using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Model
{
  public  class Author
    {

        public Author(Author author)
        {

        }
        public Author(string email, string password, string firstname, string lastname)
        {
            Email = email;
            Password = password;
            LastName = lastname;
            FirstName = firstname;
        }
        public Author(string email, string password, string firstname, string lastname, int base_id)
        {
            Email = email;
            Password = password;
            LastName = lastname;
            FirstName = firstname;
            ID = base_id;
        }

        public Author(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Author()
        {
        }

        public ISet<Quiz> Quizes { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public override string ToString() => $"ID: {ID} Firstname: {FirstName} Lastname: {LastName} Email: {Email}";


        public override bool Equals(object obj) => obj is Author a ? a.ID == ID : false;


        public override int GetHashCode() => ID.GetHashCode();


    }
}

