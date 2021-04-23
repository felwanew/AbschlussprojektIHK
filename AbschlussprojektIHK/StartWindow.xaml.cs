using Newtonsoft.Json;
using System.IO;
using System.Windows;



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

            if (File.Exists(@"User.json")) //close Startwindow when User.json already exist at start
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
                this.Close();
            }
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e) //take values from the Textbox (and the Password box) and transfer them into a Json-File
        {
            User user = new User
            {
                Firstname = Tb_Surname.Text,
                Familyname = Tb_Familyname.Text,
                MailOfInstructor = Tb_MailOfInstructor.Text,
                UserIsOnline = false,
                EmailUser = Tb_MailOfTrainee.Text,
                Password = Pwb_Password.Password
            };
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(@"appsettings.json", json);

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
    }
}
