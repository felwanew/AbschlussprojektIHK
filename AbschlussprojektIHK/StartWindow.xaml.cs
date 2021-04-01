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

            if (File.Exists(@"C:\Users\wanwitfe\source\repos\AbschlussprojektIHK\AbschlussprojektIHK\bin\Debug\User.json"))
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
                MailOfInstructor = Tb_Mail.Text,
                UserIsOnline = false
            };
            //Are the Values valid
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(@"C:\Users\wanwitfe\source\repos\AbschlussprojektIHK\AbschlussprojektIHK\bin\Debug\User.json", json);

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();

        }
    }
}
