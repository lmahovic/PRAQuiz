using PRAQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Repo
{
  public interface IRepo
    {
      ISet<Author> GetAuthors();

        ISet<Quiz> GetQuizes();

        ISet<Player> GetPlayers();

        ISet<Question> GetQuestions();

        ISet<Game> GetGames();

        ISet<Answer> GetAnswers();

        ISet<Scores> GetScores();

        int GetPlayersForQuizes(int QuizID);
        void AddScore(Scores s);
        void AddAuthor(Author a);
        int AddQuiz(Quiz q);

        void AddPlayer(Player p);

        void AddGame(Game g);

        void AddAnswer(Answer a);

        void AddQuestion(Question q);

        Author GetAuthor(int id);
        Author LoginAuthor(string email, string password);

        Quiz GetQuiz(int id);

        Answer GetAnswer(int id);

        Question GetQuestion(int id);


        ISet<Quiz> GetAuthorsQuizes(int Author_id);

        ISet<Answer> GetQuestionAnswers(int question_id);

        ISet<Question> GetQuizQuestions(int quiz_id);

        void UpdateScore(Scores s);
        void UpdateAuthor(Author a);
        void UpdateQuiz(Quiz q);
        void ResetPassword(Author a);

        void UpdatePlayer(Player p);

        void UpdateGame(Game g);

        void UpdateAnswer(Answer a);

        void UpdateQuestion(Question q);

        void DeleteQuestion(int id);

        void DeleteAuthor(int id);

        void DeleteQuiz(int id);

        void DeleteAnswer(int id);


    }
}
