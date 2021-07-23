using System.Windows;
using System;

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
            Appsettings appsettings = JSON.ReadAppsettings();
            if (appsettings.UserIsOnline == false) //check, is the user online or offline
            { // user is offline = false    user is online = true
                Btn_CurrentStatusOfPresence.Content = "Anmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind ausgeloggt";
                appsettings.UserIsOnline = true;
            }
            else
            {
                Btn_CurrentStatusOfPresence.Content = "Abmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind eingeloggt";
                appsettings.UserIsOnline = false;
            }
            JSON.ChangeAppsettingsIsOnline(appsettings);
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
            Appsettings appsettings = JSON.ReadAppsettings();
            string statusOfPresence;
            if (appsettings.UserIsOnline == false)
            { // user is offline = false    user is online = true
                Btn_CurrentStatusOfPresence.Content = "Anmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind ausgeloggt";
                statusOfPresence = "Eingeloggt";
                Tb_StatusOfWork.IsEnabled = true;
            }
            else
            {
                Btn_CurrentStatusOfPresence.Content = "Abmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind eingeloggt";
                statusOfPresence = "Ausgeloggt";
                Tb_StatusOfWork.IsEnabled = false;
                
            }
            JSON.ChangeAppsettingsIsOnline(appsettings);
            User user = JSON.ReadUser();
            try
            {
                await ClsEmail.Send_EmailAsync(user.Firstname + " " + user.Familyname + " hat sich " + statusOfPresence, Tb_StatusOfWork.Text);
            }
            catch(ArgumentException f)
            {
                Console.WriteLine(f);
            }

        }
    }
}