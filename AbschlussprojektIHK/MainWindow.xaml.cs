using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AbschlussprojektIHK
{
    /// <summary>
    /// Interaktionslogik für MainWindowUserIsOnline.xaml
    /// </summary>
    public partial class MainWindowUserIsOnline : Window
    {
        public MainWindowUserIsOnline()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SecurityQuestionReset securityQuestionReset = new SecurityQuestionReset();
            securityQuestionReset.Show();
            MainWindowUserIsOnline mainWindow = new MainWindowUserIsOnline();
            mainWindow.Close();
        }
    }
}
