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
using Newtonsoft.Json;

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
            User user = JSON.DeserializeUser();
            if (user.UserIsOnline == false)
            { // user is offline = false    user is online = true
                Btn_CurrentStatusOfPresence.Content = "Anmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind offiziell abgemeldet";
                user.UserIsOnline = true;
                JSON.SerializeUser(user);
            }
            else
            {
                Btn_CurrentStatusOfPresence.Content = "Abmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind offiziell angemeldet";
                user.UserIsOnline = false;
                JSON.SerializeUser(user);
            }
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SecurityQuestionReset securityQuestionReset = new SecurityQuestionReset();
            securityQuestionReset.ShowDialog();
            Close();
        }

        private void Btn_CurrentStatusOfPresence_Click(object sender, RoutedEventArgs e)
        {
            User user = JSON.DeserializeUser();
            if (user.UserIsOnline == false)
            { // user is offline = false    user is online = true
                Btn_CurrentStatusOfPresence.Content = "Anmelden";
                Tb_CurrentStatusOfPresence.Text = "offline";
                Tb_StatusOfWork.IsEnabled = true;
                JSON.ChangeUserIsOnline(user);
                //send Mail is missing
            }
            else
            {
                Btn_CurrentStatusOfPresence.Content = "Abmelden";
                Tb_CurrentStatusOfPresence.Text = "online";
                Tb_StatusOfWork.IsEnabled = false;
                JSON.ChangeUserIsOnline(user);
            }
        }
    }
}
