using System;

class Program
{
    static void WyswietlMenu()
    {
        Console.WriteLine("Menu systemu parkingowego:");
        Console.WriteLine("1. Zaparkuj pojazd");
        Console.WriteLine("2. Usun pojazd po numerze rejestracyjnym");
        Console.WriteLine("3. Wyswietl informacje o parkingu");
        Console.WriteLine("4. Znajdz pojazd");
        Console.WriteLine("5. Wyswietl wszystkie zaparkowane pojazdy");
        Console.WriteLine("6. Wyjscie");
        Console.Write("Wybierz opcje: ");
    }

    static void Main()
    {
        int wybor;
        SystemParkingowy systemParkingowy = new SystemParkingowy(5, 10);

        do
        {
            Console.Clear();
            WyswietlMenu();
            wybor = int.TryParse(Console.ReadLine(), out int result) ? result : 0;

            switch (wybor)
            {
                case 1:
                    {
                        Console.WriteLine();
                        Console.WriteLine("1 Samochod");
                        Console.WriteLine("2. Motocykl");
                        Console.WriteLine("3. Autobus");
                        Console.Write("Wybierz typ pojazdu: ");
                        int typPojazdu = int.Parse(Console.ReadLine());
                        Console.Write("Podaj numer rejestracyjny pojazdu: ");
                        string numerRejestracyjny = Console.ReadLine();
                        Console.Write("Podaj godzine przyjazdu (YYYY-MM-DD HH:MM): ");
                        DateTime godzinaPrzyjazdu = DateTime.Parse(Console.ReadLine());
                        Console.Write("Podaj numer wiersza: ");
                        int wiersz = int.Parse(Console.ReadLine());
                        Console.Write("Podaj numer kolumny: ");
                        int kolumna = int.Parse(Console.ReadLine());

                        Pojazd pojazd = null;
                        switch (typPojazdu)
                        {
                            case 1:
                                pojazd = new Samochod(numerRejestracyjny, godzinaPrzyjazdu);
                                break;
                            case 2:
                                pojazd = new Motocykl(numerRejestracyjny, godzinaPrzyjazdu);
                                break;
                            case 3:
                                pojazd = new Autobus(numerRejestracyjny, godzinaPrzyjazdu);
                                break;
                            default:
                                Console.WriteLine("Niepoprawny typ pojazdu.");
                                break;
                        }

                        if (pojazd != null)
                        {
                            systemParkingowy.ZaparkujPojazd(pojazd, wiersz, kolumna);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine();
                        Console.Write("Podaj numer rejestracyjny pojazdu do usuniecia: ");
                        string numerRejestracyjny = Console.ReadLine();
                        systemParkingowy.UsunPojazd(numerRejestracyjny);
                        break;
                    }
                case 3:
                    systemParkingowy.WyswietlInformacjeOParkingu();
                    break;
                case 4:
                    {
                        Console.WriteLine();
                        Console.Write("Podaj numer rejestracyjny pojazdu do wyszukania: ");
                        string numerRejestracyjny = Console.ReadLine();
                        systemParkingowy.ZnajdzPojazd(numerRejestracyjny);
                        break;
                    }
                case 5:
                    systemParkingowy.WyswietlZaparkowanePojazdy();
                    break;
                case 6:
                    Console.WriteLine("Zamykanie programu...");
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Niepoprawny wybor. Sprobuj ponownie.");
                    break;
            }
            if (wybor != 6)
            {
                Console.WriteLine("Nacisnij Enter, aby kontynuowac...");
                Console.ReadLine();
            }
        } while (wybor != 6);
    }
}