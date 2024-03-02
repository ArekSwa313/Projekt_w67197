public class MiejsceParkingowe
{
    public bool Zajete { get; set; }
    public Pojazd ZaparkowanyPojazd { get; set; }

    public MiejsceParkingowe()
    {
        Zajete = false;
        ZaparkowanyPojazd = null;
    }
}