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
    /// Logika interakcji dla klasy DodajSzkoleWindow.xaml
    /// </summary>
    public partial class DodajSzkoleWindow : Window
    {
        private List<Pele.Szkola> _szkoly;
        public DodajSzkoleWindow(ref List<Pele.Szkola> szkoly)
        {
            InitializeComponent();
            this._szkoly = szkoly;
        }

        private void zapiszClick(object sender, RoutedEventArgs e)
        {
            String nazwa = nazwa_ui.Text;
            String id = id_ui.Text;

            if (nazwa == "" || id == "")
            {
                MessageBox.Show("Pola nie mogą być puste!", "Błąd!");
                return;
            }

            _szkoly.Add(
                new Pele.Szkola(nazwa, id)
            );

            ((MainWindow)Application.Current.MainWindow).szkola_ui.Items.Add(nazwa);
            this.Close();
        }

        private void anulujClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
