using System;
using System.Collections.Generic;

namespace Pele {

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

                    if (iloscKlas == 0) return 0;
                    return suma / iloscKlas;
                }
            }
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

            public static Szkola operator + (Szkola szkola, Klasa klasa) {
                szkola.DodajKlase(klasa);
                return szkola;
            }
        }

        public class Klasa {
            public List<Uczen> uczniowie = new List<Uczen>();
            public UInt64 iloscUczniow {
                get => (UInt64) uczniowie.Count;
            }
            public int id;
            public string nazwa;
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

            public Klasa(int id, string nazwa) {
                this.id = id;
                this.nazwa = nazwa;
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

            public static Klasa operator + (Klasa klasa, Uczen uczen) {

                klasa.uczniowie.Add(uczen);

                return klasa;
            }
        }

        public class Uczen {
            public String imie;
            public String nazwisko;
            public string idUcznia {
                get {
                    return imie + " " + nazwisko;
                }
            }
            public Plec plec;
            public int id;
            // Stats
            public int inteligencja;
            public int sila;

            public Uczen(int id, String imie, String nazwisko, Plec plec, int inteligencja, int sila) {
                this.imie = imie;
                this.nazwisko = nazwisko;

                this.inteligencja = inteligencja;
                this.sila = sila;
                this.plec = plec;
                this.id = id;
            }

            public void Wyswietl() {
                Console.WriteLine("|    |--- Uczeń: " + imie + " " + nazwisko + ", " + id);
            }

            public void WyswietlStatystyki() {
                Console.WriteLine(
                    "|    |    |    Inteligencja: " + inteligencja + ", siła: " + sila 
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
                chlop = 0,
                baba = 1,
                furras = 2
            }
        }
}