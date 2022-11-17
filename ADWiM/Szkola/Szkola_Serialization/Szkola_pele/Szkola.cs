using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Pele {

        public static class GeneratorSzkolny {
            static String[] imiona = { "Mateusz", "Karol", "Łukasz", "Andrzej", "Alicja", "Emilia", "Karolina" };
            static String[] nazwiska = { "Nowacki", "Kowalski", "Pancel", "Baniak", "Galercior" };
            static String[] profile = { "programista", "elektronik", "informatyk", "automatyk", "teleinformatyk" };
            static String[] szkoly = { "Zespół Szkół Łączności", "TEB UBIKACJA", "Conradinum", "CKZIU" };
            static Dictionary<String, String> idSzkol = new Dictionary<String, String>() {
                { "Zespół Szkół Łączności",  "ZSŁ"},
                { "TEB UBIKACJA", "TEB" },
                { "Conradinum", "ĆPUN" },
                { "CKZIU", "CKZ" }
            };
            static List<String> uzyteNazwySzkol = new List<String>();

            public static Szkola GenerujSzkole(int iloscKlas = 4, int iloscUczniow = 6) {
                String nazwa = Losuj(szkoly);
                while (uzyteNazwySzkol.Find(item => item == nazwa) != null)
                {
                    nazwa = Losuj(szkoly);
                }
                uzyteNazwySzkol.Add(nazwa);
                
                String id = idSzkol[nazwa];
                Szkola szkola = new Szkola(
                    nazwa,
                    id
                );

                for (int i = 0; i < iloscKlas; i++) {
                    szkola += GenerujKlase(id, iloscUczniow);
                }

                return szkola;
            }

            public static Klasa GenerujKlase(String idSzkoly, int iloscUczniow = 6) {
                Klasa klasa = new Klasa(
                    idSzkoly,
                    Losuj(profile),
                    null,
                    Losuj(1, 6)
                );

                for (int i = 0; i < iloscUczniow; i++) {
                    klasa += GenerujUcznia(klasa.id);
                }

                return klasa;
            }

            public static Uczen GenerujUcznia(String idKlasy) {
                return new Uczen(
                    idKlasy,
                    Losuj(imiona),
                    Losuj(nazwiska),
                    Losuj(14, 22),
                    Losuj(0, 101),
                    Losuj(0, 101),
                    Losuj(0, 101),
                    Losuj(0, 101)
                );
            }

            private static UInt16 Losuj(UInt16 a, UInt16 b) {
                Random generator = new Random();

                return (UInt16) generator.Next(a, b);
            }

            private static String Losuj(String[] lista) {
                Random generator = new Random();

                return lista[generator.Next(lista.Length)];
            }
        }

        public class Szkola {
            [JsonPropertyOrder(0)]
            [JsonInclude]
            public String nazwa;
            
            [JsonInclude]
            [JsonPropertyOrder(1)]
            public String id;
            
            [JsonPropertyOrder(2)]
            [JsonInclude]
            public List<Klasa> klasy { get; } = new List<Klasa>();
            
            [JsonIgnore]
            public UInt64 iloscKlas {
                get => (UInt64) klasy.Count;
            }
            
            [JsonIgnore]
            public Double sredniaInteligencja {
                get {
                    Double suma = 0.0;
                    foreach (Klasa klasa in klasy) {
                        suma += klasa.sredniaInteligencja;
                    }

                    if (iloscKlas == 0) return 0;
                    return suma / iloscKlas;
                }
            }
            
            [JsonIgnore]
            public Double sredniaSila {
                get {
                    Double suma = 0.0;
                    foreach (Klasa klasa in klasy) {
                        suma += klasa.sredniaSila;
                    }

                    if (iloscKlas == 0) return 0;
                    return suma / iloscKlas;
                }
            }
            
            [JsonIgnore]
            public Double sredniaZwinnosc {
                get {
                    Double suma = 0.0;
                    foreach (Klasa klasa in klasy) {
                        suma += klasa.sredniaZwinnosc;
                    }

                    if (iloscKlas == 0) return 0;
                    return suma / iloscKlas;
                }
            }
            
            [JsonIgnore]
            public Double sredniaCharyzma {
                get {
                    Double suma = 0.0;
                    foreach (Klasa klasa in klasy) {
                        suma += klasa.sredniaCharyzma;
                    }

                    if (iloscKlas == 0) return 0;
                    return suma / iloscKlas;
                }
            }
            

            // public Szkola(string nazwa, string id, List<Klasa>? klasy = null) {
            //     this.nazwa = nazwa;
            //     this.id = id;
            //     if (klasy != null) {
            //         this.klasy = klasy;
            //     }
            // }

            [JsonConstructor]
            public Szkola(string nazwa, string id, Pele.Klasa[]? klasy = null) {
                this.nazwa = nazwa;
                this.id = id;
                if (klasy != null && klasy.Length > 0) {
                    this.klasy = klasy.ToList();
                }
            }

            public void DodajKlase(Klasa klasa) {
                klasy.Add(klasa);
            }
            
            public void DodajKlase(List<Klasa> klasy) {
                foreach (Klasa k in klasy) {
                    this.klasy.Add(k);
                }
            }

            public void Wyswietl(Boolean statystyki) {
                Console.WriteLine(nazwa);
                if (statystyki == true) {
                    WyswietlStatystyki();
                }
                foreach (Klasa k in klasy) {
                    Console.WriteLine("|");
                    k.Wyswietl(statystyki);
                }
            }

            public void WyswietlStatystyki() {
                Console.WriteLine("|  Średnia: ");
                Console.WriteLine(
                    "|  |   inteligencja: " + sredniaInteligencja + ", siła: " + sredniaSila + ", zwinność: " + sredniaZwinnosc +
                    ", charyzma: " + sredniaCharyzma
                );
            }

            public static Szkola operator + (Szkola szkola, Klasa klasa) {
                szkola.DodajKlase(klasa);
                return szkola;
            }
        }

        public class Klasa {
            [JsonInclude]
            [JsonPropertyName("idSzkoly")]
            public String id { get; }
            
            [JsonInclude]
            public String profil { get; }
            
            [JsonInclude]
            public List<Uczen> uczniowie { get; } = new List<Uczen>();
            
            [JsonIgnore]
            public UInt64 iloscUczniow {
                get => (UInt64) uczniowie.Count;
            }
            
            [JsonInclude]
            public UInt16 rocznik { get; } = 1; 

            [JsonIgnore]
            public Double procentChlopow { get; }
            
            [JsonIgnore]
            public Double sredniaInteligencja {
                get {
                    long suma = 0;
                    foreach (Uczen uczen in uczniowie) {
                        suma += uczen.inteligencja;
                    }

                    if (uczniowie.Count == 0) return 0.0;
                    return suma / uczniowie.Count;
                }
            }
            
            [JsonIgnore]
            public Double sredniaSila {
                get {
                    long suma = 0;
                    foreach (Uczen uczen in uczniowie) {
                        suma += uczen.sila;
                    }

                    if (uczniowie.Count == 0) return 0.0;
                    return suma / uczniowie.Count;
                }
            }
            
            [JsonIgnore]
            public Double sredniaZwinnosc {
                get {
                    long suma = 0;
                    foreach (Uczen uczen in uczniowie) {
                        suma += uczen.zwinnosc;
                    }

                    if (uczniowie.Count == 0) return 0.0;
                    return suma / uczniowie.Count;
                }
            }
            
            [JsonIgnore]
            public Double sredniaCharyzma {
                get {
                    long suma = 0;
                    foreach (Uczen uczen in uczniowie) {
                        suma += uczen.charyzma;
                    }

                    if (uczniowie.Count == 0) return 0.0;
                    return suma / uczniowie.Count;
                }
            }

            /*public Klasa(String idSzkoly, String profil, List<Uczen>? uczniowie = null, UInt16? rocznik = null) {
                if (uczniowie != null) {
                    this.uczniowie = uczniowie;
                }
                if (rocznik != null) {
                    this.rocznik = (UInt16) rocznik;
                }
                this.profil = profil;
                this.id = GenerujId(idSzkoly, this.rocznik, profil);
            }*/

            [JsonConstructor]
            public Klasa(String idSzkoly, String profil, Uczen[]? uczniowie, UInt16? rocznik = null) {
                this.id = idSzkoly;
                this.profil = profil;
                if (uczniowie != null && uczniowie.Length > 0) {
                    this.uczniowie = uczniowie.ToList();
                }
                this.rocznik = rocznik ?? this.rocznik;
            }

            public Klasa DodajUcznia(Uczen uczen) {
                return this + uczen;
            }

            public Klasa DodajUcznia(List<Uczen> uczniowie) {
                foreach (var uczen in uczniowie) {
                    DodajUcznia(uczen);
                }
                return this;
            }

            public void Wyswietl(Boolean statystyki = false) {
                Console.WriteLine("|--- Klasa: " + id);
                if (statystyki == true) {
                    WyswietlStatystyki();
                }
                Console.WriteLine("|    |");
                foreach (Uczen uczen in uczniowie) {
                    uczen.Wyswietl();
                    if (statystyki == true) {
                        uczen.WyswietlStatystyki();
                    }
                }
            }

            public void WyswietlStatystyki() {
                Console.WriteLine("|    Profil: " + profil + ", ilość osób: " + iloscUczniow);
                Console.WriteLine("|    Średnia: ");
                Console.WriteLine(
                    "|    |    inteligencja: " + sredniaInteligencja + ", siła: " + sredniaSila + ", zwinność: " + sredniaZwinnosc +
                    ", charyzma: " + sredniaCharyzma
                );
            }

            public static Klasa operator + (Klasa klasa, Uczen uczen) {

                klasa.uczniowie.Add(uczen);

                return klasa;
            }

            // e.g. idKlas["ZSŁ"][3]["programista"]
            protected static Dictionary<String, Dictionary<UInt16, Char>> idKlas =
                new Dictionary<String, Dictionary<UInt16, Char>>();

            protected static String GenerujId(String idSzkoly, UInt16 rocznik, String profil) {
                
                if (!idKlas.ContainsKey(idSzkoly)) {
                    idKlas.Add(idSzkoly, new Dictionary<UInt16, Char>());
                }

                if (idKlas[idSzkoly].ContainsKey(rocznik)) {
                    idKlas[idSzkoly][rocznik] = (Char) (idKlas[idSzkoly][rocznik] + 1);
                }
                else {
                    idKlas[idSzkoly][rocznik] = 'a';
                }
                return idSzkoly + "/" + rocznik + idKlas[idSzkoly][rocznik];
            }
        }

        public class Uczen {
            [JsonIgnore]
            public String id { get; }
            
            [JsonInclude]
            public String idKlasy { get; }
            
            [JsonInclude]
            public String imie;
            
            [JsonInclude]
            public String nazwisko;

            [JsonInclude]
            public UInt16 wiek;
            
            // Stats
            [JsonInclude]
            public UInt16 inteligencja;
            
            [JsonInclude]
            public UInt16 sila;
            
            [JsonInclude]
            public UInt16 zwinnosc;
            
            [JsonInclude]
            public UInt16 charyzma;
            
            [JsonIgnore]
            public Plec plec { get; }

            [JsonConstructor]
            public Uczen(String idKlasy, String imie, String nazwisko, UInt16 wiek, UInt16 inteligencja, UInt16 sila, UInt16 zwinnosc, UInt16 charyzma) {
                this.imie = imie;
                this.nazwisko = nazwisko;
                this.wiek = wiek;
                this.inteligencja = inteligencja;
                this.sila = sila;
                this.zwinnosc = zwinnosc;
                this.charyzma = charyzma;
                this.idKlasy = idKlasy;
                
                this.id = GenerujId(idKlasy) + ". " + imie + " " + nazwisko;
                if (imie[imie.Length - 1] == 'a') {
                    plec = Plec.baba;
                }
                else {
                    plec = Plec.chlop;
                }
            }
            
            public void Wyswietl() {
                Console.WriteLine("|    |--- Uczeń: " + imie + " " + nazwisko + ", " + id);
            }

            public void WyswietlStatystyki() {
                Console.WriteLine(
                    "|    |    |    Inteligencja: " + inteligencja + ", siła: " + sila + ", zwinność: " + zwinnosc + ", charyzma: " + charyzma
                );
            }

            // Static 
            protected static Dictionary<String, UInt64> idUczniow = new Dictionary<String, UInt64>();

            static String GenerujId(String idKlasy) {

                if (idUczniow.ContainsKey(idKlasy)) {
                    idUczniow[idKlasy]++;
                }
                else {
                    idUczniow[idKlasy] = 1;
                }

                return idKlasy + "/" + idUczniow[idKlasy];
            }

            public enum Plec {
                chlop,
                baba,
                furras
            }
        }
}