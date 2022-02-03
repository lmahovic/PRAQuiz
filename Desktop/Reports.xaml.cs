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
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        private static readonly IRepo repo = RepoFactory.GetRepository();

        public Reports()
        {
            InitializeComponent();

            var quizes = repo.GetQuizes();
            var games = repo.GetGames();



            dataReports.ItemsSource = quizes;
          
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
