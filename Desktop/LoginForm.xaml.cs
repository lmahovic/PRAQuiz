using PRAQuiz.Model;
using PRAQuiz.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        private static readonly IRepo repo = RepoFactory.GetRepository();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogInConfirm_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;

          
            string password = txtPassword.Password.ToString();

            try
            {
                //bool validEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);


                Author author = repo.LoginAuthor(email, password);

                if (author!=null)
                {
                     Lobby lobby = new Lobby(author);
                        lobby.Show();
                        this.Hide();
                    
                   
                }

                else
                {
                    MessageBoxResult result = MessageBox.Show("Wrong e-mail or password", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ResetPassword();
            if (dialog.ShowDialog() == true)
            {
                

                string email= dialog.ResponseTextBoxEmail.Text;
                string password= dialog.ResponseTextBoxPassword.Password.ToString();

                Author a = new Author(email, password);
                try
                {
                   
                        repo.ResetPassword(a);

                        MessageBoxResult result = MessageBox.Show($"Password reset for {email}", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    

                  
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
              
            }
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Close();
        }
    }
}
