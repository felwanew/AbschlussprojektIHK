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

namespace AbschlussprojektIHK
{
    /// <summary>
    /// Interaktionslogik für PasswordCheck.xaml
    /// </summary>
    public partial class PasswordCheck : Window
    {
        public PasswordCheck()
        {
            InitializeComponent();
        }

        private void Btn_Abort_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Btn_Continue_ClickAsync(object sender, RoutedEventArgs e)
        {
            User user = JSON.DeserializeUser();
            string statusOfPresence;
            if (user.UserIsOnline == false)
            { // user is offline = false    user is online = true
                Btn_CurrentStatusOfPresence.Content = "Anmelden";
                Tb_CurrentStatusOfPresence.Text = "offline";
                statusOfPresence = Tb_CurrentStatusOfPresence.Text;
                Tb_StatusOfWork.IsEnabled = true;
                JSON.ChangeUserIsOnline(user);
            }
            else
            {
                Btn_CurrentStatusOfPresence.Content = "Abmelden";
                Tb_CurrentStatusOfPresence.Text = "online";
                statusOfPresence = Tb_CurrentStatusOfPresence.Text;
                Tb_StatusOfWork.IsEnabled = false;
                JSON.ChangeUserIsOnline(user);
            }
            await ClsEmail.Send_EmailAsync(user.Firstname + " " + user.Familyname + " ist jetzt " + statusOfPresence, Tb_StatusOfWork.Text);
        }
    }
}
