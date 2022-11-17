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
using System.Windows.Shapes;

namespace Szkola_pele
{
    /// <summary>
    /// Logika interakcji dla klasy DodajKlaseWindow.xaml
    /// </summary>
    public partial class DodajKlaseWindow : Window
    {
        private Pele.Szkola _szkola;
        public DodajKlaseWindow(ref Pele.Szkola szkola)
        {
            InitializeComponent();
            this._szkola = szkola;
        }

        private void zapiszClick(object sender, RoutedEventArgs e)
        {
            String profil = profil_ui.Text;
            String rocznik = rocznik_ui.Text;

            if (profil == "" || rocznik == "")
            {
                MessageBox.Show("Pola nie mogą być puste!", "Błąd!");
                return;
            }

            UInt32 rocz;
            if (!UInt32.TryParse(rocznik, out rocz))
            {
                MessageBox.Show("Rok klasy musi być liczbą!", "Błąd!");
                return;
            }

            _szkola.DodajKlase(
                new Pele.Klasa(_szkola.id, profil, null, (ushort) rocz)
            );

            ((MainWindow)Application.Current.MainWindow).klasa_ui.Items.Add(_szkola.klasy.Last().id);
            this.Close();
        }

        private void anulujClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
