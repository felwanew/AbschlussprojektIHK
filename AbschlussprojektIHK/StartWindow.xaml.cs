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
using System.Windows.Shapes;
using Newtonsoft.Json;



namespace AbschlussprojektIHK
{
    /// <summary>
    /// Interaktionslogik für StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {            
            InitializeComponent();
            if (File.Exists(@"User.json"))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
                this.Close();
            }
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                Firstname = Tb_Surname.Text,
                Familyname = Tb_Familyname.Text,
                MailOfInstructor = Tb_MailOfInstructor.Text,
                UserIsOnline = false,
                EmailUser = Tb_MailOfTrainee.Text,
                PasswordUser = Pb_PasswordOfTraineeMail.Password
            };
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(@"User.json", json);

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
    }
}
