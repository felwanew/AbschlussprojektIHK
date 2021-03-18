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
                User user = new User();
                var json = File.ReadAllText(@"User.json");
                bool userIsOnline = Convert.ToBoolean(json[3]);
                MainWindowUserIsOnline mainWindow = new MainWindowUserIsOnline();
                mainWindow.Show();
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowUserIsOnline mainWindow = new MainWindowUserIsOnline();

            User user = new User
            {
                Firstname = Tb_Surname.Text,
                Familyname = Tb_Familyname.Text,
                MailOfInstructor = Tb_Mail.Text,
                UserIsOnline = false
            };
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            System.IO.File.WriteAllText(@"User.json", json);
            mainWindow.Show();
            Close();
        }
    }
}
