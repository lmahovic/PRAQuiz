using PRAQuiz.Model;
using PRAQuiz.Repo;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UpdateQuestion.xaml
    /// </summary>
    public partial class UpdateQuestion : Window
    {
        private static readonly IRepo repo = RepoFactory.GetRepository();
        public UpdateQuestion(int idQuestion)
        {
            InitializeComponent();

            Question question = new Question();
            ISet<Answer> answers = new HashSet<Answer>();

            question = repo.GetQuestion(idQuestion);
            answers = repo.GetQuestionAnswers(idQuestion);


            List<string> vs = new List<string>();
            List<bool> vs1 = new List<bool>();
            List<int> vs2= new List<int>();

            foreach (var item in answers)
            {
                vs.Add(item.Text);
                vs1.Add(item.Correct);
                vs2.Add(item.ID);
            }

            txtAnswer1.Text = vs[0];
            txtAnswer2.Text = vs[1];
            txtAnswer3.Text = vs[2];
            txtAnswer4.Text = vs[3];
            txtAID1.Text = vs2[0].ToString();
            txtAID2.Text = vs2[1].ToString();
            txtAID3.Text = vs2[2].ToString();
            txtAID4.Text = vs2[3].ToString();

            cb1.IsChecked = vs1[0];
            cb2.IsChecked = vs1[1];
            cb3.IsChecked = vs1[2];
            cb4.IsChecked = vs1[3];

            txtQuestionId.Text = question.ID.ToString();
            txtQuestionText.Text = question.QuestionText;
            txtTimeLimit.Text = question.TimeLimit.ToString();
            txtQuizId.Text = question.QuizID.ToString();
        }

        private void btnSAveChanges_Click(object sender, RoutedEventArgs e)
        {
            int idQuestion = int.Parse(txtQuestionId.Text);
            string questionText = txtQuestionText.Text;
            int timeLimit =int.Parse( txtTimeLimit.Text);
            int ID = int.Parse(txtQuestionId.Text);
            int QuizId = int.Parse(txtQuizId.Text);
            string answ1 = txtAnswer1.Text;
            string answ2 = txtAnswer2.Text;
            string answ3 = txtAnswer3.Text;
            string answ4 = txtAnswer4.Text;
            bool c1 = (bool)cb1.IsChecked;
            bool c2 = (bool)cb2.IsChecked;
            bool c3 = (bool)cb3.IsChecked;
            bool c4 = (bool)cb4.IsChecked;
            int a1ID = int.Parse( txtAID1.Text);
            int a2ID = int.Parse( txtAID2.Text);
            int a3ID = int.Parse( txtAID3.Text);
            int a4ID = int.Parse( txtAID4.Text);

            Question question = new Question(questionText, QuizId, timeLimit, ID);
            Answer answer1 = new Answer(answ1 , idQuestion,a1ID, c1  );
            Answer answer2= new Answer(answ2 , idQuestion,a2ID, c2  );
            Answer answer3 = new Answer(answ3 , idQuestion,a3ID, c3 );
            Answer answer4 = new Answer(answ4 , idQuestion,a4ID, c4  );

            try
            {
                repo.UpdateQuestion(question);
                repo.UpdateAnswer(answer1);
                repo.UpdateAnswer(answer2);
                repo.UpdateAnswer(answer3);
                repo.UpdateAnswer(answer4);

                MessageBoxResult result = MessageBox.Show("Changes accepted", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
