using System;
using System.IO;
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
using Newtonsoft.Json;

namespace AbschlussprojektIHK
{
    /// <summary>
    /// Interaktionslogik für SecurityQuestionReset.xaml
    /// </summary>
    public partial class SecurityQuestionReset : Window
    {
        public SecurityQuestionReset()
        {
            InitializeComponent();
        }

        private void Btn_ResetOk_Click(object sender, RoutedEventArgs e)
        {
            File.Delete(@"User.json");
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
        }

        private void Btn_Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
