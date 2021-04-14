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
        private string StatusOfWork { get; set; }
        private string StatusOfPresence { get; set; }
        public PasswordCheck(string _StatusOfWork, string _StatusOfPresence) //status of presence
        {
            InitializeComponent();
            StatusOfWork = _StatusOfWork;
            StatusOfPresence = _StatusOfPresence;
        }



        private void Btn_Abort_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Btn_Continue_ClickAsync(object sender, RoutedEventArgs e)
        {
            User user = JSON.DeserializeUser();
            if (user.UserIsOnline == false)
            { // user is offline = false    user is online = true
                JSON.ChangeUserIsOnline(user);
            }
            else
            {
                JSON.ChangeUserIsOnline(user);
            }
            ClsEmail.Password = Pwb_Password.Password;
            await ClsEmail.Send_EmailAsync(user.Firstname + " " + user.Familyname + " ist jetzt " + StatusOfPresence, StatusOfWork);
        }
    }
}
