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
            UserFormularWindow startWindow = new UserFormularWindow();
            startWindow.Show();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
            Close();
        }

        private void Btn_Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
