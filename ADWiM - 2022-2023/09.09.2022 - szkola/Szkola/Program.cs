using System;
using System.Collections.Generic;

namespace Pele {
    class Program {

        public static class GeneratorSzkolny {
            static String[] imiona = { "Mateusz", "Karol", "Łukasz", "Andrzej", "Alicja", "Emilia", "Karolina" };
            static String[] nazwiska = { "Nowacki", "Kowalski", "Pancel", "Baniak", "Galercior" };
            static String[] profile = { "programista", "elektronik", "informatyk", "automatyk", "teleinformatyk" };
            static String[] szkoly = { "Zespół Szkół Łączności", "TEB UBIKACJA", "Conradinum", "CKZIU" };
            static Dictionary<String, String> idSzkol = new Dictionary<String, String>() {
                { "Zespół Szkół Łączności",  "ZSŁ"},
                { "TEB UBIKACJA", "TEB" },
                { "Conradinum", "CON" },
                { "CKZIU", "CKZ" }
            };

            public static Szkola GenerujSzkole(int iloscKlas = 4, int iloscUczniow = 6) {
                String nazwa = Losuj(szkoly);
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
            public String nazwa;
            public String id;
            public List<Klasa> klasy { get; } = new List<Klasa>();
            public UInt64 iloscKlas {
                get => (UInt64) klasy.Count;
            }
            public Double sredniaInteligencja {
                get {
                    Double suma = 0.0;
                    foreach (Klasa klasa in klasy) {
                        suma += klasa.sredniaInteligencja;
                    }

                    return suma / iloscKlas;
                }
            }
            public Double sredniaSila {
                get {
                    Double suma = 0.0;
                    foreach (Klasa klasa in klasy) {
                        suma += klasa.sredniaSila;
                    }

                    return suma / iloscKlas;
                }
            }
            public Double sredniaZwinnosc {
                get {
                    Double suma = 0.0;
                    foreach (Klasa klasa in klasy) {
                        suma += klasa.sredniaZwinnosc;
                    }

                    return suma / iloscKlas;
                }
            }
            public Double sredniaCharyzma {
                get {
                    Double suma = 0.0;
                    foreach (Klasa klasa in klasy) {
                        suma += klasa.sredniaCharyzma;
                    }

                    return suma / iloscKlas;
                }
            }

            public Szkola(string nazwa, string id, List<Klasa>? klasy = null) {
                this.nazwa = nazwa;
                this.id = id;
                if (klasy != null) {
                    this.klasy = klasy;
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
            public List<Uczen> uczniowie { get; } = new List<Uczen>();
            public UInt64 iloscUczniow {
                get => (UInt64) uczniowie.Count;
            }
            public UInt16 rocznik { get; } = 1; 
            public String id { get; }
            public String profil { get; }
            public Double procentChlopow { get; }
            public Double sredniaInteligencja {
                get {
                    long suma = 0;
                    foreach (Uczen uczen in uczniowie) {
                        suma += uczen.inteligencja;
                    }

                    return suma / uczniowie.Count;
                }
            }
            public Double sredniaSila {
                get {
                    long suma = 0;
                    foreach (Uczen uczen in uczniowie) {
                        suma += uczen.sila;
                    }

                    return suma / uczniowie.Count;
                }
            }
            public Double sredniaZwinnosc {
                get {
                    long suma = 0;
                    foreach (Uczen uczen in uczniowie) {
                        suma += uczen.zwinnosc;
                    }

                    return suma / uczniowie.Count;
                }
            }
            public Double sredniaCharyzma {
                get {
                    long suma = 0;
                    foreach (Uczen uczen in uczniowie) {
                        suma += uczen.charyzma;
                    }

                    return suma / uczniowie.Count;
                }
            }

            public Klasa(String idSzkoly, String profil, List<Uczen>? uczniowie = null, UInt16? rocznik = null) {
                if (uczniowie != null) {
                    this.uczniowie = uczniowie;
                }
                if (rocznik != null) {
                    this.rocznik = (UInt16) rocznik;
                }
                this.profil = profil;
                this.id = GenerujId(idSzkoly, this.rocznik, profil);
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
            public String imie;
            public String nazwisko;
            public Plec plec { get; }
            public String id { get; }
            public UInt16 wiek;
            // Stats
            public UInt16 inteligencja;
            public UInt16 sila;
            public UInt16 zwinnosc;
            public UInt16 charyzma;

            public Uczen(String idKlasy, String imie, String nazwisko, UInt16 wiek, UInt16 inteligencja, UInt16 sila, UInt16 zwinnosc, UInt16 charyzma) {
                this.imie = imie;
                this.nazwisko = nazwisko;
                this.wiek = wiek;
                this.inteligencja = inteligencja;
                this.sila = sila;
                this.zwinnosc = zwinnosc;
                this.charyzma = charyzma;

                this.id = GenerujId(idKlasy);
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

        static void Main(string[] args) {
            Szkola test = GeneratorSzkolny.GenerujSzkole();
            test.Wyswietl(true);
        }
    }
}