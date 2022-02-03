using PRAQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Repo
{
    class MemoryRepo: IRepo
    {
        private FileRepository r = new FileRepository();

        private ISet<Player> players = new HashSet<Player>();
        private ISet<Answer> answers = new HashSet<Answer>();
        private ISet<Question> questions = new HashSet<Question>();
        private ISet<Author> Authors = new HashSet<Author>();
        private ISet<Quiz> quizes = new HashSet<Quiz>();
        private ISet<Scores> scores = new HashSet<Scores>();
        private ISet<Game> games = new HashSet<Game>();

        public MemoryRepo()
        {
            FillItems();
        }

        private void FillItems()
        {
            players = r.GetPlayers();
            answers = r.GetAnswers();
            questions = r.GetQuestions();
            questions.ToList().ForEach(qu => qu.Answers = r.GetQuestionAnswers(qu.ID));
            Authors = r.GetAuthors();
            Authors.ToList().ForEach(a => a.Quizes = r.GetAuthorsQuizes(a.ID));
            quizes = r.GetQuizes();
            quizes.ToList().ForEach(q => q.Questions = r.GetQuizQuestions(q.ID));
            scores = r.GetScores();
            games = r.GetGames();
        }

        public void AddAnswer(Answer a)
        {
            answers.Add(a);
            r.AddAnswer(a);
        }

        public void AddAuthor(Author a)
        {
            Authors.Add(a);
            r.AddAuthor(a);
        }

        public void AddGame(Game g)
        {
            games.Add(g);
            r.AddGame(g);
        }

        public void AddPlayer(Player p)
        {
            players.Add(p);
            r.AddPlayer(p);
        }

        public void AddQuestion(Question q)
        {
            questions.Add(q);
            r.AddQuestion(q);
        }

        public int AddQuiz(Quiz q)
        {
            quizes.Add(q);
          return  r.AddQuiz(q);

            
        }
        public void AddScore(Scores s)
        {
            scores.Add(s);
            r.AddScore(s);

        }

        public ISet<Answer> GetAnswers() => new HashSet<Answer>(answers);

        public ISet<Author> GetAuthors() => new HashSet<Author>(Authors);


        public ISet<Game> GetGames() => new HashSet<Game>(games);


        public ISet<Player> GetPlayers() => new HashSet<Player>(players);


        public ISet<Question> GetQuestions() => new HashSet<Question>(questions);


        public ISet<Quiz> GetQuizes() => new HashSet<Quiz>(quizes);


        public ISet<Scores> GetScores() => new HashSet<Scores>(scores);

        public Author GetAuthor(int id) => Authors.FirstOrDefault(a => a.ID == id);
        public Quiz GetQuiz(int id) => quizes.FirstOrDefault(q => q.ID == id);


        public Answer GetAnswer(int id) => answers.FirstOrDefault(a => a.ID == id);

        public Question GetQuestion(int id) => questions.FirstOrDefault(q => q.ID == id);


        public ISet<Quiz> GetAuthorsQuizes(int Author_id) => new HashSet<Quiz>(r.GetAuthorsQuizes(Author_id));


        public ISet<Answer> GetQuestionAnswers(int question_id) => new HashSet<Answer>(r.GetQuestionAnswers(question_id));


        public ISet<Question> GetQuizQuestions(int quiz_id) => new HashSet<Question>(r.GetQuizQuestions(quiz_id));

        public void UpdateScore(Scores s) => r.UpdateScore(s);

        public void UpdateAuthor(Author a) => r.UpdateAuthor(a);


        public void UpdateQuiz(Quiz q) => r.UpdateQuiz(q);


        public void UpdatePlayer(Player p) => r.UpdatePlayer(p);


        public void UpdateGame(Game g) => r.UpdateGame(g);


        public void UpdateAnswer(Answer a) => r.UpdateAnswer(a);


        public void UpdateQuestion(Question q) => r.UpdateQuestion(q);


        public void DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuiz(int id) => r.DeleteQuiz(id);

        public void DeleteAnswer(int id) => r.DeleteAnswer(id);
       

        public void DeleteQuestion(int id) => r.DeleteQuestion(id);
      

        public Author LoginAuthor(string email, string password)=> Authors.FirstOrDefault(a => a.Email == email && a.Password==password);



        public void ResetPassword(Author a) => r.ResetPassword(a);

        public int GetPlayersForQuizes(int QuizID) => r.GetPlayersForQuizes(QuizID);
       
    }
}
