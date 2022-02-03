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
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {
        private static readonly IRepo repo = RepoFactory.GetRepository();
     

        public Lobby(Model.Author author)
        {
            InitializeComponent();

          

            txtUserName.Text = author.FirstName + " " + author.LastName;

            getQuizes();
        }

        private void getQuizes()
        {

            try
            {
                var quizes = repo.GetQuizes();
              
                dataQuiz.ItemsSource = quizes;
                

               
            }
            catch (Exception)
            {

                MessageBoxResult result = MessageBox.Show("Nije moguće dohvatiti kvizove", "Obavijest", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
         


        }

        private void btnPasswordChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idQuiz = int.Parse(dataQuiz.SelectedValue.ToString());

                if (idQuiz!=0)
                {
                    
                    QuizDetails quizDetails = new QuizDetails(idQuiz);
                    quizDetails.Show();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Choose quiz to view details", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception)
            {

                throw;
            }

          
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRename_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idQuiz = int.Parse(dataQuiz.SelectedValue.ToString());

            try
            {
                repo.DeleteQuiz(idQuiz);

             
                MessageBoxResult result = MessageBox.Show("Quiz deleted", "Info", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                getQuizes();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

          
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            
            CreateQuiz createQuiz = new CreateQuiz();
            createQuiz.Show();
           
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();

            reports.Show();
        }
    }
}
