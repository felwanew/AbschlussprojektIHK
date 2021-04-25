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
        private User user = new User();
        public StartWindow()
        {
            InitializeComponent();
            user = JSON.ReadUser();
            Tb_Surname.Text = user.Firstname;
            Tb_Familyname.Text = user.Familyname;
            Tb_MailOfInstructor.Text = user.MailOfInstructor;
            Tb_MailOfTrainee.Text = user.EmailUser;
            Pwb_Password.Password = user.Password;
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e) //take values from the Textbox (and the Password box) and transfer them into a Json-File
        {
            user.Firstname = Tb_Surname.Text;
            user.Familyname = Tb_Familyname.Text;
            user.MailOfInstructor = Tb_MailOfInstructor.Text;
            user.EmailUser = Tb_MailOfTrainee.Text;
            user.Password = Pwb_Password.Password;
            JSON.WriteUser(user);

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
    }
}
