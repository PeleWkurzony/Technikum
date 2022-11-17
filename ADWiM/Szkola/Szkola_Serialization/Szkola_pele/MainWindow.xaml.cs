using Pele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Szkola_pele
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Pele.Szkola> _szkoly = new List<Pele.Szkola>() { };
        public MainWindow() {
            //var test = Pele.Serializer.WczytajDane();
            Pele.Serializer.Test();
            InitializeComponent();
            const int ilosc_szkol = 3;
            for (int i = 0; i < ilosc_szkol; i++)
            {
                var szkola = Pele.GeneratorSzkolny.GenerujSzkole();
                _szkoly.Add(szkola);
                szkola_ui.Items.Add(szkola.nazwa);
            }
        }

        private void szkola_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            klasa_ui.Items.Clear();
            String id = e.AddedItems[0] as String;
            Pele.Szkola szkola = null;
            foreach (var szk in _szkoly)
            {
                if (szk.nazwa == id)
                {
                    szkola = szk;
                }
            }
            foreach (var klasa in szkola.klasy)
            {
                klasa_ui.Items.Add(klasa.id);
            }
            opis_ui.Text = "Klasa: " + szkola.id + "\nIlość klas: " + szkola.iloscKlas +
            "\nStatystyki:\nŚrednia Inteligencja: " + szkola.sredniaInteligencja + "\nŚrednia Siła: " + szkola.sredniaSila + "\nŚrednia Zwinność: " +
            szkola.sredniaZwinnosc + "\nŚrednia Charyzma: " + szkola.sredniaCharyzma;
        }

        private void klasa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uczen_ui.Items.Clear();
            Pele.Szkola szkola = znajdzSzkole();
            String id = null;
            try
            {
                id = e.AddedItems[0] as String;
            }
            catch (System.IndexOutOfRangeException w)
            {

            }
            if (id == null)
            {
                uczen_ui.Items.Clear();
                return;
            }
            Pele.Klasa klasa = null;
            foreach (var kla in szkola.klasy)
            {
                if (kla.id == id)
                {
                    klasa = kla;
                }
            }
            foreach (var uczniowie in klasa.uczniowie)
            {
                uczen_ui.Items.Add(uczniowie.id);
            }
            opis_ui.Text = "Klasa: " + klasa.id + "\nIlość uczniów: " + klasa.iloscUczniow + "\nProfil: " + klasa.profil +
                "\nStatystyki:\nŚrednia Inteligencja: " + klasa.sredniaInteligencja + "\nŚrednia Siła: " + klasa.sredniaSila + "\nŚrednia Zwinność: " +
                klasa.sredniaZwinnosc + "\nŚrednia Charyzma: " + klasa.sredniaCharyzma;
        }

        private void uczen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pele.Szkola szkola = znajdzSzkole();
            Pele.Klasa klasa = znajdzKlase(szkola);
            Pele.Uczen uczen = null;
            String id = null;
            try
            {
                id = e.AddedItems[0] as String;
            }
            catch (System.IndexOutOfRangeException w)
            {

            }
            finally
            {
                opis_ui.Text = "";
            }
            
            if (id == null)
            {
                return;
            }

            foreach (var ucz in klasa.uczniowie)
            {
                if (ucz.id == id)
                {
                    uczen = ucz;
                }
            }

            opis_ui.Text = "Uczeń: " + uczen.imie + " " + uczen.nazwisko + "\n" + "Wiek: " + uczen.wiek + "\n" + "Płeć: " +
                uczen.plec.ToString() + "\n" + "Statystyki:\n" + "Inteligencja: " + uczen.inteligencja.ToString() + "\nSiła: " + uczen.sila.ToString() +
                "\nZwinność: " + uczen.zwinnosc + "\nCharyzma: " + uczen.charyzma;
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
            String id = klasa_ui.SelectedItem as String;
            foreach (var klasa in szkola.klasy)
            {
                if (klasa.id == id)
                {
                    return klasa;
                }
            }

            return null;
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

        private void MainWindow_OnClosing(object? sender, CancelEventArgs e) {
            Pele.Serializer.ZapiszDane(_szkoly);
        }
    }
}
