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

namespace Szkola_pele
{
    /// <summary>
    /// Logika interakcji dla klasy DodajUczniaWindow.xaml
    /// </summary>
    public partial class DodajUczniaWindow : Window {
        private Pele.Klasa _klasa;
        public DodajUczniaWindow(ref Pele.Klasa klasa) {

            InitializeComponent();
            this._klasa = klasa;
        }

        private void zapiszClick(object sender, RoutedEventArgs e) {
            String imie = imie_ui.Text;
            String nazwisko = nazwisko_ui.Text;
            UInt16 wiek;
            UInt16 inteligencja;
            UInt16 sila;
            UInt16 zwinnosc;
            UInt16 charyzma;

            if (imie == "" || nazwisko == "" || wiek_ui.Text == "" || inteligencja_ui.Text == "" || sila_ui.Text == "" || zwinnosc_ui.Text == "" || charyzma_ui.Text == "") {
                MessageBox.Show("Pola nie mogą być puste!", "Błąd");
                return;
            }

            if (!UInt16.TryParse(wiek_ui.Text, out wiek) || 
                !UInt16.TryParse(inteligencja_ui.Text, out inteligencja) ||
                !UInt16.TryParse(sila_ui.Text, out sila) ||
                !UInt16.TryParse(zwinnosc_ui.Text, out zwinnosc) ||
                !UInt16.TryParse(charyzma_ui.Text, out charyzma)
            ) {
                MessageBox.Show("Podano niewłaściwe informacje:", "Błąd!");
                return;
            }

            ((MainWindow) Application.Current.MainWindow).uczen_ui.Items.Add(
                _klasa.uczniowie.Last().id
            );

            this.Close();
        }

        private void anulujClick(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
