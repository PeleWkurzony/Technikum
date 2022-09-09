#include <string>
#include <sstream>
#include <iostream>

class PrzedmiotSzkolny {
public:
    std::string nazwaPrzedmiotu;
    unsigned short int liczbaGodzinTygodniowo;
    std::string wydawnictwoPodrecznika;

    PrzedmiotSzkolny(std::string nazwa, unsigned short int godziny, std::string wydawnictwo)
        : nazwaPrzedmiotu(nazwa), liczbaGodzinTygodniowo(godziny), wydawnictwoPodrecznika(wydawnictwo) {}

    operator std::string() {
        std::stringstream ss;
        unsigned int godziny = liczbaGodzinTygodniowo * 30;
        ss << nazwaPrzedmiotu << ", " << godziny << " godzin, wydawnictwo:  " << wydawnictwoPodrecznika;
        return ss.str();
    }

    void wypisz() {
        std::cout << static_cast<std::string> (*this);
    }
};

class PrzedmiotZawodowy : public PrzedmiotSzkolny {
public:
    std::string kodKwalifikacji;
    
    PrzedmiotZawodowy(std::string nazwa, unsigned short int godziny, std::string wydawnictwo, std::string kwalifikacja)
        : PrzedmiotSzkolny(nazwa, godziny, wydawnictwo), kodKwalifikacji(kwalifikacja) {}

    operator std::string() {
        std::stringstream ss;
        unsigned int godziny = liczbaGodzinTygodniowo * 30;
        ss << nazwaPrzedmiotu << ", " << godziny << " godzin, wydawnictwo:  " << wydawnictwoPodrecznika << ", kwalifikacja: " << kodKwalifikacji;
        return ss.str();
    }

    void wypisz() {
        std::cout << static_cast<std::string> (*this);
    }
};

int main() {
    PrzedmiotSzkolny wos("Wiedza o Społeczeństwie", 1u, "wsip");
    wos.wypisz();

    PrzedmiotZawodowy prSiO("PrSiO", 3u, "brak", "INF.04");
    std::cout << std::endl << static_cast<std::string> (prSiO) << std::endl;
    return 0;
}