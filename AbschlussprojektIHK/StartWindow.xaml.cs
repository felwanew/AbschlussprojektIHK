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

/*{
    public class JSONString
    {
        public static List<Buch> ErstelleKatalog(Bücherkatalog bücherkatalog)
        {
            var json = File.ReadAllText(@"C:\Users\wanwitfe\source\repos\ExersiceJSON\ExersiceJSON\Buecherei\books.json");
            return bücherkatalog.KatalogBücher = JsonConvert.DeserializeObject<List<Buch>>(json);
        }
        static public void SpeichereBücherkatalog(List<Buch> BücherListe)
        {
            string json = JsonConvert.SerializeObject(BücherListe);
            System.IO.File.WriteAllText(@"C:\Users\wanwitfe\source\repos\ExersiceJSON\ExersiceJSON\Buecherei\books.json", json);
        }
        public static List<Exemplar> ErstelleInventar(List<Exemplar> ExemplarListe)
        {
            string json = JsonConvert.SerializeObject(ExemplarListe);
            System.IO.File.WriteAllText(@"C:\Users\wanwitfe\source\repos\ExersiceJSON\ExersiceJSON\Buecherei\exemplare.json", json);
        }
    }
}*/

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
                var json = File.ReadAllText(@"User.json");
                User user = JsonConvert.DeserializeObject<User>(json);

                if (user.UserIsOnline == false)
                {
                    MainWindow mainWindow = new MainWindow();
                    //change of content of StatusOfPresence
                    mainWindow.ShowDialog();
                    this.Close();
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.ShowDialog();
                    this.Close();
                }

            }
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            User user = new User
            {
                Firstname = Tb_Surname.Text,
                Familyname = Tb_Familyname.Text,
                MailOfInstructor = Tb_Mail.Text,
                UserIsOnline = false
            };
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            System.IO.File.WriteAllText(@"User.json", json);
            mainWindow.ShowDialog();
            this.Close();
        }
    }
}
