using System.Windows;

namespace AbschlussprojektIHK
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //change content of StatusOfPresence
            Appsettings appsettings = JSON.DeserializeUser();
            if (appsettings.UserIsOnline == false) //check, is the user online or offline
            { // user is offline = false    user is online = true
                Btn_CurrentStatusOfPresence.Content = "Anmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind abgemeldet";
                appsettings.UserIsOnline = true;
                JSON.SerializeUser(appsettings);
            }
            else
            {
                Btn_CurrentStatusOfPresence.Content = "Abmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind angemeldet";
                appsettings.UserIsOnline = false;
                JSON.SerializeUser(appsettings);
            }
        }
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Btn_Reset_Click(object sender, RoutedEventArgs e) //call SecurityQuestionReset Window
        {

            SecurityQuestionReset securityQuestionReset = new SecurityQuestionReset();
            securityQuestionReset.ShowDialog();
            this.Close();
        }
        private async void Btn_CurrentStatusOfPresence_ClickAsync(object sender, RoutedEventArgs e) //call method to send mail + change the mainwindow to show the user, if online or offline
        {
            Appsettings appsettings = JSON.DeserializeUser();
            string statusOfPresence;
            if (user.appsettings == false)
            { // user is offline = false    user is online = true
                Btn_CurrentStatusOfPresence.Content = "Anmelden";
                Tb_CurrentStatusOfPresence.Text = "offline";
                statusOfPresence = Tb_CurrentStatusOfPresence.Text;
                Tb_StatusOfWork.IsEnabled = true;
                JSON.ChangeAppsettingsIsOnline(appsettings);
            }
            else
            {
                Btn_CurrentStatusOfPresence.Content = "Abmelden";
                Tb_CurrentStatusOfPresence.Text = "online";
                statusOfPresence = Tb_CurrentStatusOfPresence.Text;
                Tb_StatusOfWork.IsEnabled = false;
                JSON.ChangeAppsettingsIsOnline(appsettings);
            }
            User user = JSON.DeserializeUser();
            await ClsEmail.Send_EmailAsync(user.Firstname + " " + user.Familyname + " ist jetzt " + statusOfPresence, Tb_StatusOfWork.Text);
        }
    }
}