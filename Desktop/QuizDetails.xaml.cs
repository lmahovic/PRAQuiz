using PRAQuiz.Model;
using PRAQuiz.Repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PRAQuiz
{
    /// <summary>
    /// Interaction logic for QuizDetails.xaml
    /// </summary>
    public partial class QuizDetails : Window
    {

        private static readonly IRepo repo = RepoFactory.GetRepository();
        public QuizDetails(int idQuiz)
        {
            InitializeComponent();

            getDetails(idQuiz);
        }

        private void getDetails(int idQuiz)


        {

            ISet<Answer> answers = new HashSet<Answer>();
            ObservableCollection<Question> questions = new ObservableCollection<Question>();

            Answer answer1 = new Answer();


            try
            {
                Quiz quiz = new Quiz();

                

                quiz= repo.GetQuiz(idQuiz);
                var qQ = repo.GetQuizQuestions(idQuiz);
             

               
            

                foreach (var item in qQ)
                {
                    answers = repo.GetQuestionAnswers(item.ID);
                   

                   
                   

                    Question question = new Question(answers, idQuiz, item.ID, item.QuestionText, item.TimeLimit);


                    questions.Add(question);



                }

                

                quizDetails.DataContext = questions;

                lbQuizName.Content = quiz.Title.ToString();
                lbTimesPlayed.Content = "Times played: " + quiz.TimesPlayed.ToString();
              
                


                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                
                int idQuestion = int.Parse(quizDetails.SelectedValue.ToString());

                UpdateQuestion updateQuestion = new UpdateQuestion(idQuestion);
                updateQuestion.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Please choose question for update");
            }
          
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Quiz will start shorlty");
        }
    }
}
