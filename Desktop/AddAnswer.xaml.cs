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
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddAnswer : Window
    {
        private static readonly IRepo repo = RepoFactory.GetRepository();

        private int questionId;
        public AddAnswer(Model.Question question1)
        {
            InitializeComponent();

            questionId = question1.ID;
        }

        private void btnSaveAnswer_Click(object sender, RoutedEventArgs e)
        {
            
            bool correct = false;
           string answer= txtAnswerText.Text;

            if (chbCorrect.IsChecked==true)
            {
                correct = true;
            }
            Answer answer1 = new Answer(questionId, answer,  correct);
          

            try
            {
                repo.AddAnswer(answer1);
                MessageBoxResult result = MessageBox.Show("Answer saved", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
