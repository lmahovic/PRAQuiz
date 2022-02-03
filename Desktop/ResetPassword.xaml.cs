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
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }


        public string ResponseTextEmail
        {
            get { return ResponseTextBoxEmail.Text; }
            set { ResponseTextBoxEmail.Text = value; }
        }
        public string ResponseTextPassword
        {
            get { return ResponseTextBoxPassword.Password.ToString(); }
            set { ResponseTextBoxPassword.Password = value; }
        }

        private void btnResetPasswod_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ResponseTextBoxEmail.Text) && !string.IsNullOrEmpty(ResponseTextBoxPassword.Password.ToString()))
            {
                DialogResult = true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Fill out all fields", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
