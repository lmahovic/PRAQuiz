using PRAQuiz.Model;
using PRAQuiz.Repo;
using PRAQuiz.DAL;
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
    /// Interaction logic for SignUpForm.xaml
    /// </summary>
    /// 
   
    public partial class SignUpForm : Window
    {
        private static readonly IRepo repo = RepoFactory.GetRepository();


        public SignUpForm()
        {
            InitializeComponent();
           
    }

        private void btnSignUpConfirm_Click(object sender, RoutedEventArgs e)
        {
            

            string name = txtFirstName.Text;
            string surname = txtLastName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Password.ToString();

            try
            {
                Author author = new Author(email, password, name, surname);
                repo.AddAuthor(author);

                MessageBoxResult result = MessageBox.Show("Successful registration", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
            
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }
    }
}
