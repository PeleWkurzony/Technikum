using System.ComponentModel;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pele {
    class Serialization {

        static void Main(string[] args) {
            List<Ksiazka?>? lista = KsiazkaSerializer.ReadAll();

            String? comenda;
            String? komunikat = null;

            while (true) {
                Console.Clear();
                Console.WriteLine("Witaj w programie przechowywującym informacje o ksiązkach!\nWpisz: dodaj - aby dodać informacje o książce, lub wczytaj - aby wczytać informację\n");

                if (komunikat != null) {
                    Console.WriteLine(komunikat + "\n");
                    komunikat = null;
                }

                comenda = Console.ReadLine();

                if (comenda == "dodaj") {
                    Console.Write("Podaj nazwę: ");
                    String? nazwa = Console.ReadLine();

                    Console.Write("Podaj autora: ");
                    String? autor = Console.ReadLine();

                    Console.Write("Podaj rok wydania: ");
                    int rok_wydania;
                    while (!int.TryParse(Console.ReadLine(), out rok_wydania)) {

                    }

                    Console.Write("Podaj wydawnictwo: ");
                    String? wydawnictwo = Console.ReadLine();

                    Console.Write("Podaj język książki: ");
                    String? jezykS = Console.ReadLine();
                    jezykS = jezykS.ToLower();
                    Ksiazka.Jezyk? jezyk = null;
                    if (jezykS == "polski") {
                        jezyk = Ksiazka.Jezyk.Polski;
                    }
                    else if (jezykS == "english") {
                        jezyk = Ksiazka.Jezyk.English;
                    }

                    Ksiazka ksiazka = new Ksiazka(
                        nazwa,
                        autor,
                        rok_wydania,
                        wydawnictwo,
                        jezyk
                    );

                    KsiazkaSerializer.Add(ksiazka);
                    komunikat = "Pomyślnie dodano nową ksiązkę!";
                    lista = KsiazkaSerializer.ReadAll();

                } else if (comenda == "wczytaj") {

                    if (lista == null || lista.Count == 0) {

                        komunikat = "Nie znaleziono żadnych książek!";
                        continue;
                    }

                    Console.WriteLine("Spis książek: ");
                    for (int i = 0; i < lista.Count; i++) {
                        Console.WriteLine($"{i + 1}. {lista[i].nazwa} - {lista[i].autor}");
                    }

                    Console.Write("Podaj numer do wyświetlenia: ");
                    int numer;
                    while (!int.TryParse(Console.ReadLine(), out numer)) {

                    }
                    numer -= 1;

                    if (numer < 0 || numer >= lista.Count) {
                        komunikat = "Nie znaleziono takiej ksiązki!";
                        continue;
                    }

                    Console.Clear();

                    Ksiazka? ksiazka = lista[numer];

                    Console.WriteLine($"Nazwa: {ksiazka.nazwa}");
                    Console.WriteLine($"Autor: {ksiazka.autor}");
                    Console.WriteLine($"Rok wydania {ksiazka.rok_wydania}");
                    Console.WriteLine($"Wydawnictwo: {ksiazka.wydawnictwo}");
                    String jezyk;
                    if (ksiazka.jezyk == Ksiazka.Jezyk.Polski)
                        jezyk = "polski";
                    else if (ksiazka.jezyk == Ksiazka.Jezyk.English)
                        jezyk = "english";
                    else
                        jezyk = "nie podano";

                    Console.WriteLine($"Język: {jezyk}");
                    Console.Read();
                }
            }
        }

        public static class KsiazkaSerializer {

            private static String directoryPath = $"C:\\Users\\{Environment.UserName}\\Documents\\Pele\\";
            public static String path = $"C:\\Users\\{Environment.UserName}\\Documents\\Pele\\Ksiazki.pele";

            public static void Add(Ksiazka ksiazka) {
                if (!File.Exists(path)) {
                    Directory.CreateDirectory(directoryPath);
                    File.Create(path).Close();
                   
                }

                File.AppendAllText(path, ksiazka.ToJSON() + "\n");
            }

            public static List<Ksiazka?>? ReadAll() {
                if (!File.Exists(path)) {
                    return null;
                }

                List<Ksiazka?> list = new List<Ksiazka?>();
                using (var reader = new StreamReader(path)) {
                    String? line;
                    while ((line = reader.ReadLine()) != null) {
                        list.Add(new Ksiazka(line));
                    }

                    reader.Close();
                }

                return list;
            }
        }

        public class Ksiazka {
            public String? nazwa { get; set; }
            public String? autor { get; set; }
            public int? rok_wydania { get; set; }
            public String? wydawnictwo { get; set; }
            public Jezyk? jezyk { get; set; }

            [JsonConstructor]
            public Ksiazka(string? nazwa, string? autor, int? rok_wydania, string? wydawnictwo, Jezyk? jezyk) {
                this.nazwa = nazwa;
                this.autor = autor;
                this.rok_wydania = rok_wydania;
                this.wydawnictwo = wydawnictwo;
                this.jezyk = jezyk;
            }
            public Ksiazka(String json) {
                Ksiazka? k = JsonSerializer.Deserialize<Ksiazka>(json);
                if (k == null) {
                    return;
                }

                this.nazwa = k.nazwa;
                this.autor = k.autor;
                this.rok_wydania = k.rok_wydania;
                this.wydawnictwo = k.wydawnictwo;
                this.jezyk = k.jezyk;
            }
            public enum Jezyk {
                Polski,
                English
            }

            public String ToJSON() {
                return JsonSerializer.Serialize(this);
            }
        }
    }
}