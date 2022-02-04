using PRAQuiz.DAL;
using PRAQuiz.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAQuiz.Repo
{
    class FileRepository: IRepo
    {
      

        public FileRepository()
        {

        }

        //GET AuthorS
       public  Author GetAuthorFromDataRow(DataRow row)
        {
            string firstname = row["FirstName"].ToString();
            string lastname = row["LastName"].ToString();
            string email = row["Email"].ToString();
            string password = row["Password"].ToString();
            int id = (int)row["ID"];


            return new Author(email, password, firstname, lastname, id);
        }

       public  ISet<Author> GetAuthors()
        {
            ISet<Author> Authors = new HashSet<Author>();
            DataTable tblAuthors = DAL.DAL.ExecuteReader("GetAuthors", DAL.CommandType.StoranaProcedura);


            foreach (DataRow row in tblAuthors.Rows)
            {
                Authors.Add(GetAuthorFromDataRow(row));

            }

            return Authors;
        }
        //GET ANSWERS
        public Answer GetAnswerFromDataRow(DataRow row)
        {
            string answer = row["AnswerText"].ToString();
            bool correct = (bool)row["Correct"];
            int questionID = (int)row["QuestionID"];
            int id = (int)row["ID"];

            return new Answer(answer, questionID, id, correct);
        }

        public ISet<Answer> GetAnswers()
        {
            ISet<Answer> answers = new HashSet<Answer>();
            DataTable tblAnswer = DAL.DAL.ExecuteReader("GetAnswers", DAL.CommandType.StoranaProcedura);

            foreach (DataRow row in tblAnswer.Rows)
            {
                answers.Add(GetAnswerFromDataRow(row));

            }
            return answers;
        }
        //GET QUESTIONS
        public Question GetQuestionFromDataRow(DataRow row)
        {
            string question = row["QuestionText"].ToString();
            int time_limit = (int)row["TimeLimit"];
            int quiz_id = (int)row["QuizID"];
            int id = (int)row["ID"];

            return new Question(question, quiz_id, time_limit, id);
        }

        public ISet<Question> GetQuestions()
        {
            ISet<Question> questions = new HashSet<Question>();
            DataTable tblQuestion = DAL.DAL.ExecuteReader("GetQuestions", DAL.CommandType.StoranaProcedura);

            foreach (DataRow row in tblQuestion.Rows)
            {
                questions.Add(GetQuestionFromDataRow(row));
            }

            return questions;
        }

        //GET QUIZ
        public Quiz GetQuizFromDataRow(DataRow row)
        {
            int id = (int)row["ID"];
            string title = row["Title"].ToString();
        
            int Author_id = (int)row["AuthorID"];
           

            return new Quiz(id, title, Author_id);
        }
        public ISet<Quiz> GetQuizes()
        {
            ISet<Quiz> quizes = new HashSet<Quiz>();
            DataTable tblQuiz = DAL.DAL.ExecuteReader("GetQuizes", DAL.CommandType.StoranaProcedura);

            foreach (DataRow row in tblQuiz.Rows)
            {
                quizes.Add(GetQuizFromDataRow(row));
            }

            return quizes;
        }


        //GET PLAYER
        public Player GetPlayerFromDataRow(DataRow row)
        {
            string nickname = row["Nickname"].ToString();
            int id = (int)row["ID"];
            return new Player(nickname, id);
        }
        //public ISet<Player> GetPlayers()
        //{
        //    ISet<Player> players = new HashSet<Player>();
        //    DataTable tblPlayer = DAL.DAL.ExecuteReader("GetPlayers", DAL.CommandType.StoranaProcedura);

        //    foreach (DataRow row in tblPlayer.Rows)
        //    {
        //        players.Add(GetPlayerFromDataRow(row));
        //    }

        //    return players;
        //}

        //GET GAMES
        //public Game GetGameFromDataRow(DataRow row)
        //{

        //    DateTime datetime = DateTime.Parse(row["StartTime"].ToString());
        //    int quiz_id = (int)row["QuizID"];
        //    string gamepin = row["GamePIN"].ToString();
        //    int id = (int)row["ID"];

        //    return new Game(quiz_id, gamepin, datetime, id);

        //}
        //public ISet<Game> GetGames()
        //{
        //    ISet<Game> games = new HashSet<Game>();
        //    DataTable tblGame = DAL.DAL.ExecuteReader("GetGames", DAL.CommandType.StoranaProcedura);

        //    foreach (DataRow row in tblGame.Rows)
        //    {
        //        games.Add(GetGameFromDataRow(row));
        //    }

        //    return games;
        //}
     

    

        public Author GetAuthor(int id)
        {
            Author Author = new Author();
            DataTable tblAuthor = DAL.DAL.ExecuteReader("GetAuthor", DAL.CommandType.StoranaProcedura, new Parameter { Naziv = "@id", Value = id });

            foreach (DataRow row in tblAuthor.Rows)
            {
                Author = GetAuthorFromDataRow(row);
            }

            return Author;
        }

        public ISet<Quiz> GetAuthorsQuizes(int Author_id)
        {
            ISet<Quiz> Authors_quizes = new HashSet<Quiz>();

            DataTable tblAuthorQuizes = DAL.DAL.ExecuteReader("GetAuthorsQuizes", DAL.CommandType.StoranaProcedura, new Parameter { Naziv = "@id", Value = Author_id });

            foreach (DataRow row in tblAuthorQuizes.Rows)
            {
                Authors_quizes.Add(GetQuizFromDataRow(row));
            }

            return Authors_quizes;
        }

        public ISet<Answer> GetQuestionAnswers(int question_id)
        {
            ISet<Answer> question_answers = new HashSet<Answer>();

            DataTable tblQuestionAnswers = DAL.DAL.ExecuteReader("GetQuestionAnswers", DAL.CommandType.StoranaProcedura, new Parameter { Naziv = "@id", Value = question_id });

            foreach (DataRow row in tblQuestionAnswers.Rows)
            {
                question_answers.Add(GetAnswerFromDataRow(row));
            }

            return question_answers;
        }

        public ISet<Question> GetQuizQuestions(int quiz_id)
        {
            ISet<Question> quiz_questions = new HashSet<Question>();

            DataTable tblQuizQuestions = DAL.DAL.ExecuteReader("GetQuizQuestions", DAL.CommandType.StoranaProcedura, new Parameter { Naziv = "@id", Value = quiz_id });

            foreach (DataRow row in tblQuizQuestions.Rows)
            {
                quiz_questions.Add(GetQuestionFromDataRow(row));
            }

            return quiz_questions;
        }

        public void AddAuthor(Author a)
        {
            a.ID = DAL.DAL.AddEntity("AddAuthor",
                  new Parameter { Naziv = "@Email", Value = a.Email },
                  new Parameter { Naziv = "@Password", Value = a.Password },
                  new Parameter { Naziv = "@FirstName", Value = a.FirstName },
                  new Parameter { Naziv = "@LastName", Value = a.LastName });
        }

        public int AddQuiz(Quiz q)
        {
            q.ID = DAL.DAL.AddEntity("AddQuiz",
                new Parameter { Naziv = "@Title", Value = q.Title },
                new Parameter { Naziv = "@AuthorID", Value = q.AutorID });

            return q.ID;
        }

        public void AddPlayer(Player p)
        {
            p.ID = DAL.DAL.AddEntity("AddPlayer",
                 new Parameter { Naziv = "@Nickname", Value = p.Nickname });
        }

        public void AddGame(Game g)
        {
            g.ID = DAL.DAL.AddEntity("AddGame",
                new Parameter { Naziv = "@GamePIN", Value = g.GamePIN },
                new Parameter { Naziv = "@QuizID", Value = g.QuizID }
                );
        }

        public void AddAnswer(Answer a)
        {
            a.ID = DAL.DAL.AddEntity("AddAnswer",
                new Parameter { Naziv = "@AnswerText", Value = a.Text },
                new Parameter { Naziv = "@Correct", Value = a.Correct },
                new Parameter { Naziv = "@QuestionID", Value = a.questionID }
                );
        }

        public void AddQuestion(Question q)
        {
            q.ID = DAL.DAL.AddEntity("AddQuestion",
               new Parameter { Naziv = "@QuestionText", Value = q.QuestionText },
               new Parameter { Naziv = "@TimeLimit", Value = q.TimeLimit },
               new Parameter { Naziv = "@QuizID", Value = q.QuizID }
               );
        }


        public void AddScore(Scores s)
        {
            s.ID = DAL.DAL.AddEntity("AddScores",
             new Parameter { Naziv = "@GameID", Value = s.GameID },
             new Parameter { Naziv = "@QuestionsPlayed", Value = s.QuestionsPlayed },
             new Parameter { Naziv = "@Accuracy", Value = s.Accuracy },
             new Parameter { Naziv = "@Score", Value = s.Score }
             );
        }

        public void UpdateScore(Scores s)
        {
            DAL.DAL.ExecuteCommand("UpdateScores",
            new Parameter { Naziv = "@id", Value = s.ID },
            new Parameter { Naziv = "@playerid", Value = s.PlayerID },
            new Parameter { Naziv = "@gameid", Value = s.GameID },
            new Parameter { Naziv = "@questionsplayed", Value = s.QuestionsPlayed },
            new Parameter { Naziv = "@accuracy", Value = s.Accuracy },
            new Parameter { Naziv = "@score", Value = s.Score }
            );
        }


        public void UpdateAuthor(Author a)
        {
            DAL.DAL.ExecuteCommand("UpdateAuthor",
                            new Parameter { Naziv = "@email", Value = a.Email },
                            new Parameter { Naziv = "@id", Value = a.ID },
                            new Parameter { Naziv = "@Passw", Value = a.Password },
                            new Parameter { Naziv = "@FirstName", Value = a.FirstName },
                            new Parameter { Naziv = "@LastName", Value = a.LastName });
        }

        public void UpdateQuiz(Quiz q)
        {
            DAL.DAL.ExecuteCommand("UpdateQuiz",
                new Parameter { Naziv = "@id", Value = q.ID },
                new Parameter { Naziv = "@title", Value = q.Title },
                new Parameter { Naziv = "@Authorid", Value = q.AutorID });
        }

        public void UpdatePlayer(Player p)
        {
            DAL.DAL.ExecuteCommand("UpdatePlayer",
           new Parameter { Naziv = "@nickname", Value = p.Nickname },
           new Parameter { Naziv = "@id", Value = p.ID }
           );
        }

        public void UpdateGame(Game g)
        {
            DAL.DAL.ExecuteCommand("UpdateGame",
                new Parameter { Naziv = "@id", Value = g.ID },
                new Parameter { Naziv = "@date", Value = g.DatePlayed },
                new Parameter { Naziv = "@quizid", Value = g.QuizID },
                new Parameter { Naziv = "@gamepin", Value = g.GamePIN }

                );
        }

        public void UpdateAnswer(Answer a)
        {
            DAL.DAL.ExecuteCommand("UpdateAnswer",
                 new Parameter { Naziv = "@answer", Value = a.Text },
                 new Parameter { Naziv = "@id", Value = a.ID },
                 new Parameter { Naziv = "@correct", Value = a.Correct },
                 new Parameter { Naziv = "@questionID", Value = a.questionID }
                 );
        }

        public void UpdateQuestion(Question q)
        {
            DAL.DAL.ExecuteCommand("UpdateQuestion",
               new Parameter { Naziv = "@question", Value = q.QuestionText },
               new Parameter { Naziv = "@id", Value = q.ID },
               new Parameter { Naziv = "@timelimit", Value = q.TimeLimit },
               new Parameter { Naziv = "@quizid", Value = q.QuizID }
               );
        }

        public void DeleteAuthor(int id)
        {
            DAL.DAL.ExecuteCommand("DeleteAuthor", new Parameter { Naziv = "@id", Value = id });
        }

        public void DeleteQuiz(int id)
        {
            DAL.DAL.ExecuteCommand("DeleteQuiz", new Parameter { Naziv = "@id", Value = id });
        }

        public void DeleteAnswer(int id)
        {
            DAL.DAL.ExecuteCommand("DeleteAnswer", new Parameter { Naziv = "@id", Value = id });
        }
        public void DeleteQuestion(int id)
        {
            DAL.DAL.ExecuteCommand("DeleteQuestion", new Parameter { Naziv = "@id", Value = id });
        }

        public Quiz GetQuiz(int id)
        {
            Quiz q = new Quiz();
            DataTable tblQuiz = DAL.DAL.ExecuteReader("GetQuiz", DAL.CommandType.StoranaProcedura, new Parameter { Naziv = "@id", Value = id });

            foreach (DataRow row in tblQuiz.Rows)
            {
                q = GetQuizFromDataRow(row);
            }

            return q;
        }

        public Answer GetAnswer(int id)
        {
            Answer a = new Answer();
            DataTable tblAnswer = DAL.DAL.ExecuteReader("GetAnswer", DAL.CommandType.StoranaProcedura, new Parameter { Naziv = "@id", Value = id });

            foreach (DataRow row in tblAnswer.Rows)
            {
                a = GetAnswerFromDataRow(row);
            }

            return a;
        }

        public Question GetQuestion(int id)
        {
            Question q = new Question();
            DataTable tblQuestion = DAL.DAL.ExecuteReader("GetQuestion", DAL.CommandType.StoranaProcedura, new Parameter { Naziv = "@id", Value = id });

            foreach (DataRow row in tblQuestion.Rows)
            {
                q = GetQuestionFromDataRow(row);
            }

            return q;
        }

        public Author LoginAuthor(string email, string password)
        {
            Author Author = new Author();
            DataTable tblAuthor = DAL.DAL.ExecuteReader("LoginAuthor", DAL.CommandType.StoranaProcedura, new Parameter { Naziv = "@email", Value = email } ,
                new Parameter { Naziv = "@passw", Value = password });

            foreach (DataRow row in tblAuthor.Rows)
            {
                Author = GetAuthorFromDataRow(row);
            }

            return Author;
        }

        public void ResetPassword(Author a)
        {
            DAL.DAL.ExecuteCommand("ResetPassword",
               new Parameter { Naziv = "@email", Value = a.Email },
               new Parameter { Naziv = "@password", Value = a.Password }
             
               );
        }

        public int GetPlayersForQuizes(int QuizID)
        {

            return NotImplementedException();

        }

        private int NotImplementedException()
        {
            throw new NotImplementedException();
        }
    }


}
