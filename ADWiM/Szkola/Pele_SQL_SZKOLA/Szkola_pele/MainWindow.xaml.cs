using Pele;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Common;

namespace Szkola_pele
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Pele.Szkola> _szkoly = new List<Pele.Szkola>();

        private Dictionary<string, int> _idSzkol = new Dictionary<string, int>();
        private Dictionary<string, int> _idKlas = new Dictionary<string, int>();

        public MainWindow()
        {
            InitializeComponent();
            ZaladujSzkoly();
            foreach (Pele.Szkola p in _szkoly) {
                szkola_ui.Items.Add(p.nazwa);
            }
        }

        private void ZaladujSzkoly() {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-C6S519S\\BAZASQL,1433;Initial Catalog=BazaSzkolna;User ID=login2;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")) {
                con.Open();
                using (SqlCommand sql = new SqlCommand("SELECT * FROM [dbo].[Table]", con)) {
                    using (DbDataReader reader = sql.ExecuteReader()) {
                        while (reader.Read()) {
                            int id = (int) reader.GetValue(0);
                            string nazwa = reader.GetString(1);
                            string skrot = reader.GetString(2);

                            Szkola szkola = new Szkola(nazwa, skrot);
                            _idSzkol.Add(skrot, id);
                            ZaladujKlase(ref szkola);
                            _szkoly.Add(szkola);
                        }
                    }   
                con.Close();
                }
            }
        }

        private void ZaladujKlase(ref Pele.Szkola szkola) {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-C6S519S\\BAZASQL,1433;Initial Catalog=BazaSzkolna;User ID=login2;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")) {
                con.Open();
                int idSzkoly = _idSzkol[szkola.id];
                using (SqlCommand sql = new SqlCommand($"SELECT * FROM [dbo].[klasy] WHERE id_szkoly = {idSzkoly}", con)) {
                    using (DbDataReader reader = sql.ExecuteReader()) {
                        while (reader.Read()) {
                            int id = reader.GetInt32(0);
                            string nazwa_klasy = reader.GetString(1);
                            
                            Pele.Klasa klasa = new Klasa(id, nazwa_klasy);
                            ZaladujUczniow(ref klasa);
                            szkola.DodajKlase(klasa);
                        }
                    }   
                    con.Close();
                }
            }
        } 

        private void ZaladujUczniow(ref Pele.Klasa klasa) {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-C6S519S\\BAZASQL,1433;Initial Catalog=BazaSzkolna;User ID=login2;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")) {
                con.Open();
                using (SqlCommand sql = new SqlCommand($"SELECT * FROM [dbo].[uczniowie] WHERE id_klasy = {klasa.id}", con)) {
                    using (DbDataReader reader = sql.ExecuteReader()) {
                        while (reader.Read()) {
                            int id = reader.GetInt32(0);
                            string imie = reader.GetString(1);
                            string nazwisko = reader.GetString(2);
                            Pele.Uczen.Plec plec = (Pele.Uczen.Plec) reader.GetValue(3);
                            int inteligencja = reader.GetInt32(4);
                            int sila = reader.GetInt32(5);

                            Uczen uczen = new Uczen(id, imie, nazwisko, plec, inteligencja, sila);
                            klasa.DodajUcznia(uczen);
                        }
                    }   
                    con.Close();
                }
            }
        }

        private void szkola_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            klasa_ui.Items.Clear();
            string nazwaSzkoly = (string) szkola_ui.SelectedItem;
            Pele.Szkola? szkola = _szkoly.Find(x => x.nazwa == nazwaSzkoly);
            if (szkola == null) {
                return;
            }

            foreach (var klasy in szkola.klasy) {
                klasa_ui.Items.Add(klasy.nazwa);
            }

            opis_ui.Text = "Klasa: " + szkola.id + "\nIlość klas: " + szkola.iloscKlas +
            "\nStatystyki:\nŚrednia Inteligencja: " + szkola.sredniaInteligencja + "\nŚrednia Siła: " + szkola.sredniaSila;
        }

        private void klasa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uczen_ui.Items.Clear();
            Pele.Szkola? szkola = _szkoly.Find(x => x.nazwa == (string) (szkola_ui.SelectedItem));
            if (szkola == null) return;
            Pele.Klasa? klasa = szkola.klasy.Find(klasa => klasa.nazwa == (string) (klasa_ui.SelectedItem));
            if (klasa == null) return;

            foreach (var uczen in klasa.uczniowie) {
                uczen_ui.Items.Add(uczen.idUcznia);
            }

            opis_ui.Text = "Klasa: " + klasa.id + "\nIlość uczniów: " + klasa.iloscUczniow + 
                "\nStatystyki:\nŚrednia Inteligencja: " + klasa.sredniaInteligencja + "\nŚrednia Siła: " + klasa.sredniaSila;
        }

        private void uczen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pele.Szkola? szkola = _szkoly.Find(x => x.nazwa == (string) (szkola_ui.SelectedItem));
            if (szkola == null) return;
            Pele.Klasa? klasa = szkola.klasy.Find(klasa => klasa.nazwa == (string) (klasa_ui.SelectedItem));
            if (klasa == null) return;
            Pele.Uczen? uczen = klasa.uczniowie.Find(uczen => uczen.idUcznia == (string) (uczen_ui.SelectedItem));
            if (uczen == null) return;

            opis_ui.Text = "Uczeń: " + uczen.imie + " " + uczen.nazwisko + "\n" + "\n" + "Płeć: " +
                uczen.plec.ToString() + "\n" + "Statystyki:\n" + "Inteligencja: " + uczen.inteligencja.ToString() + "\nSiła: " + uczen.sila.ToString();
        }

        private Pele.Szkola znajdzSzkole()
        {
            String id = szkola_ui.SelectedItem as String;
            foreach (var szkola in _szkoly)
            {
                if (szkola.nazwa == id)
                {
                    return szkola;
                }
            }

            return null;
        }

        private Pele.Klasa znajdzKlase(Pele.Szkola szkola)
        {
            throw new NotImplementedException();
        }

        private void dodajSzkole(object sender, RoutedEventArgs e)
        {
            new DodajSzkoleWindow(ref _szkoly).Show();
        }

        private void dodajKlase(object sender, RoutedEventArgs e)
        {
            if (szkola_ui.SelectedItem == null)
            {
                MessageBox.Show("Wybierz szkołę!", "Błąd!");
                return;
            }

            Pele.Szkola szkola = znajdzSzkole();
            new DodajKlaseWindow(ref szkola).Show();
        }

        private void dodajUcznia(object sender, RoutedEventArgs e)
        {
            if (klasa_ui.SelectedItem == null)
            {
                MessageBox.Show("Wybierz klasę!", "Błąd!");
                return;
            }

            Pele.Szkola szkola = znajdzSzkole();
            Pele.Klasa klasa = znajdzKlase(szkola);

            new DodajUczniaWindow(ref klasa).Show();

        }

    }
}
