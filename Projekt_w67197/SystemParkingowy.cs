public class SystemParkingowy
{
    private Parking parking;

    public SystemParkingowy(int wiersze, int kolumny)
    {
        parking = new Parking(wiersze, kolumny);
    }

    public void ZaparkujPojazd(Pojazd pojazd, int wiersz, int kolumna)
    {
        parking.ZaparkujPojazd(pojazd, wiersz, kolumna);
    }

    public void UsunPojazd(string numerRejestracyjny)
    {
        parking.UsunPojazd(numerRejestracyjny);
    }

    public void WyswietlInformacjeOParkingu()
    {
        parking.WyswietlInformacjeOParkingu();
    }

    public void ZnajdzPojazd(string numerRejestracyjny)
    {
        parking.ZnajdzPojazd(numerRejestracyjny);
    }

    public void WyswietlZaparkowanePojazdy()
    {
        parking.WyswietlZaparkowanePojazdy();
    }
}