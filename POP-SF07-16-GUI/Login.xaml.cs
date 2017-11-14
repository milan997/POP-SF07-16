using POP_SF07_16.Model;
using POP_SF07_16_GUI.DAL;
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

namespace POP_SF07_16_GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            string username = KorisnickoIme.Text;
            string password = Lozinka.Text;
            bool login = LoginValidan(username, password);
            if (login)
            {
                var window = new MainWindow();
                this.Close();
                window.Show();
            } else
            {
                MessageBox.Show("Neispravni kreditencijali!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static bool LoginValidan(string username, string password)
        {
            bool login = false;
            foreach (Korisnik k in KorisnikDAL.GetList())
            {
                if (k.KorIme == username.Trim() && k.Lozinka == password.Trim())
                {
                    login = true;
                    break;
                }
            }
            return login;
        }
    }
}
