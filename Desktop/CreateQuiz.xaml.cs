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
    /// Interaction logic for CreateQuiz.xaml
    /// </summary>
    public partial class CreateQuiz : Window
    {
        private static readonly IRepo repo = RepoFactory.GetRepository();

        private int QuizID;

        Question question1 = new Question();

        public CreateQuiz()
        {
           
            InitializeComponent();


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string quizTitle = txtQuizTitle.Text;

            PRAQuiz.Model.Quiz quiz = new Model.Quiz(quizTitle, 1);

            try
            {
                QuizID= repo.AddQuiz(quiz);

               

                MessageBoxResult result = MessageBox.Show("Quiz saved", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
           
        }

        private void btnAnwer1_Click(object sender, RoutedEventArgs e)
        {
            AddAnswer addanswer = new AddAnswer(question1);

            addanswer.Show();
        }

        private void btnAnswer2_Click(object sender, RoutedEventArgs e)
        {
            AddAnswer addanswer = new AddAnswer(question1);

            addanswer.Show();
        }

        private void btnAnswer3_Click(object sender, RoutedEventArgs e)
        {
            AddAnswer addanswer = new AddAnswer(question1);

            addanswer.Show();
        }

        private void btnAnswer4_Click(object sender, RoutedEventArgs e)
        {
            AddAnswer addanswer = new AddAnswer(question1);

            addanswer.Show();
        }

        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
          

            string question=txtQuestionEntry.Text;
            string timeLimit = (cbTimeLimit.SelectedItem as ComboBoxItem).Content.ToString().Substring(0,2);
            int timeInt = Int32.Parse(timeLimit);
            string noAnswers = cbNoAnswer.SelectedItem.ToString();

             question1 = new Question(question, QuizID, timeInt);

            try
            {
               
                repo.AddQuestion(question1);
                var qstns= repo.GetQuizQuestions(QuizID);

                

             
                MessageBoxResult result = MessageBox.Show("Question saved", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                dataQuestions.Visibility = Visibility.Visible;
                dataQuestions.DataContext = qstns;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            


        }

        private void btnDeleteQuestion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
