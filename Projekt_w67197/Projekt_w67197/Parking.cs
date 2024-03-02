using System;
using System.Collections.Generic;

public class Parking
{
    private List<List<MiejsceParkingowe>> miejsca;
    private int wiersze, kolumny;

    public Parking(int wiersze, int kolumny)
    {
        this.wiersze = wiersze * 2 - 1;
        this.kolumny = kolumny;
        miejsca = new List<List<MiejsceParkingowe>>();

        for (int i = 0; i < this.wiersze; i++)
        {
            var wiersz = new List<MiejsceParkingowe>();
            if (i % 2 == 0)
            {
                for (int j = 0; j < kolumny; j++)
                {
                    wiersz.Add(new MiejsceParkingowe());
                }
            }
            miejsca.Add(wiersz);
        }
    }

    public bool CzyMiejsceDostepne(int wiersz, int kolumna, int zajmowaneMiejsca)
    {
        wiersz = (wiersz - 1) * 2;
        kolumna -= 1;

        if (wiersz < 0 || wiersz >= wiersze || kolumna < 0 || kolumna + zajmowaneMiejsca > kolumny) return false;
        for (int i = 0; i < zajmowaneMiejsca; ++i)
        {
            if (miejsca[wiersz][kolumna + i].Zajete) return false;
        }
        return true;
    }

    public void ZaparkujPojazd(Pojazd pojazd, int wiersz, int kolumna)
    {
        if (!CzyMiejsceDostepne(wiersz, kolumna, pojazd.MiejscaZajmowane()))
        {
            Console.WriteLine("Nie ma wystarczającej ilości miejsc lub miejsce jest już zajęte!");
            return;
        }

        wiersz = (wiersz - 1) * 2;
        kolumna -= 1;
        for (int i = 0; i < pojazd.MiejscaZajmowane(); ++i)
        {
            miejsca[wiersz][kolumna + i].Zajete = true;
            miejsca[wiersz][kolumna + i].ZaparkowanyPojazd = pojazd;
        }
        Console.WriteLine($"Pojazd {pojazd.NumerRe()} zaparkowany pomyślnie.");
    }

    public void UsunPojazd(string numerRejestracyjny)
    {
        bool pojazdZnaleziony = false;
        for (int i = 0; i < wiersze; i += 2)
        {
            for (int j = 0; j < kolumny; ++j)
            {
                if (miejsca[i][j].Zajete && miejsca[i][j].ZaparkowanyPojazd.NumerRe() == numerRejestracyjny)
                {
                    miejsca[i][j].Zajete = false;
                    miejsca[i][j].ZaparkowanyPojazd = null;
                    pojazdZnaleziony = true;
                }
            }
        }

        if (pojazdZnaleziony)
        {
            Console.WriteLine($"Pojazd {numerRejestracyjny} usunięty pomyślnie.");
        }
        else
        {
            Console.WriteLine($"Pojazd o numerze {numerRejestracyjny} nie został znaleziony.");
        }
    }

    public void WyswietlZaparkowanePojazdy()
    {
        Console.WriteLine();
        Console.WriteLine("Lista zaparkowanych pojazdów:");
        var zaparkowanePojazdy = new HashSet<string>();

        for (int i = 0; i < wiersze; i += 2)
        {
            foreach (var miejsce in miejsca[i])
            {
                if (miejsce.Zajete && zaparkowanePojazdy.Add(miejsce.ZaparkowanyPojazd.NumerRe()))
                {
                    var pojazd = miejsce.ZaparkowanyPojazd;
                    Console.WriteLine($"Numer rejestracyjny: {pojazd.NumerRe()}, Godzina przyjazdu: {pojazd.GodzinaPrzyjazdu().ToString("yyyy-MM-dd HH:mm")}");
                }
            }
        }

        if (zaparkowanePojazdy.Count == 0)
        {
            Console.WriteLine("Brak zaparkowanych pojazdów.");
        }
    }

    public void WyswietlInformacjeOParkingu()
    {
        Console.WriteLine();
        Console.WriteLine("Informacje o parkingu:");
        for (int i = 0; i < wiersze; i++)
        {
            if (i % 2 == 1)
            {
                Console.WriteLine(new string(' ', kolumny * 3));
                continue;
            }

            foreach (var miejsce in miejsca[i])
            {
                Console.Write(miejsce.Zajete ? "[X]" : "[ ]");
            }
            Console.WriteLine();
        }
    }

    public void ZnajdzPojazd(string numerRejestracyjny)
    {
        for (int i = 0; i < wiersze; i += 2)
        {
            for (int j = 0; j < kolumny; ++j)
            {
                if (miejsca[i][j].Zajete && miejsca[i][j].ZaparkowanyPojazd.NumerRe() == numerRejestracyjny)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Znaleziono pojazd o numerze rejestracyjnym {numerRejestracyjny}:");
                    Console.WriteLine($"Typ pojazdu: {miejsca[i][j].ZaparkowanyPojazd.TypPojazdu()}");
                    Console.WriteLine($"Godzina przyjazdu: {miejsca[i][j].ZaparkowanyPojazd.GodzinaPrzyjazdu().ToString("yyyy-MM-dd HH:mm")}");
                    Console.WriteLine($"Miejsce zaparkowania: {((i / 2) + 1)}, {j + 1}");
                    return;
                }
            }
        }
        Console.WriteLine($"Pojazd o numerze rejestracyjnym {numerRejestracyjny} nie został znaleziony na parkingu.");
    }
}
