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
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
//using Outlook = Microsoft.Office.Interop.Outlook;

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
            User user = (User)JSON.DeserializePath(@"User.json");
            if (user.UserIsOnline == false)
            { // user is offline = false    user is online = true
                Btn_CurrentStatusOfPresence.Content = "Anmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind abgemeldet";
                user.UserIsOnline = true;
                JSON.SerializePath(user, @"User.json");
            }
            else
            {
                Btn_CurrentStatusOfPresence.Content = "Abmelden";
                Tb_CurrentStatusOfPresence.Text = "Sie sind angemeldet";
                user.UserIsOnline = false;
                JSON.SerializePath(user, @"User.json");
            }
        }
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            SecurityQuestionReset securityQuestionReset = new SecurityQuestionReset();
            securityQuestionReset.ShowDialog();
        }
        private async void Btn_CurrentStatusOfPresence_ClickAsync(object sender, RoutedEventArgs e)
        {
            User user = (User)JSON.DeserializePath(@"User.json");
            string statusOfPresence;
            if (user.UserIsOnline == false)
            { // user is offline = false    user is online = true
                Btn_CurrentStatusOfPresence.Content = "Anmelden";
                Tb_CurrentStatusOfPresence.Text = "offline";
                statusOfPresence = Tb_CurrentStatusOfPresence.Text;
                Tb_StatusOfWork.IsEnabled = true;
                JSON.ChangeUserIsOnline(user);
                //MAPI mapi = new MAPI();
                //mapi.AddRecipientTo("felwanew@outlook.de");
                //mapi.SendMailDirect("subject", "body");
                //send Mail is missing
            }
            else
            {
                Btn_CurrentStatusOfPresence.Content = "Abmelden";
                Tb_CurrentStatusOfPresence.Text = "online";
                statusOfPresence = Tb_CurrentStatusOfPresence.Text;
                Tb_StatusOfWork.IsEnabled = false;
                JSON.ChangeUserIsOnline(user);
            }
            await ClsEmail.Send_EmailAsync(user.Firstname + " " + user.Familyname + " ist jetzt " + statusOfPresence,Tb_StatusOfWork.Text); //probably issue with the smtp server
        }
    }
}