using System.IO;
using System.Windows;

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

        private void Btn_ResetOk_Click(object sender, RoutedEventArgs e) //Delete JSON and call startwindow 
        {
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
