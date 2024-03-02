using System;

public abstract class Pojazd
{
    protected string numerRejestracyjny;
    protected int zajmowaneMiejsca;
    protected DateTime godzinaPrzyjazdu;

    public Pojazd(string numer, int miejsca, DateTime przyjazd)
    {
        numerRejestracyjny = numer;
        zajmowaneMiejsca = miejsca;
        godzinaPrzyjazdu = przyjazd;
    }

    public abstract string TypPojazdu();
    public string NumerRe() => numerRejestracyjny;
    public int MiejscaZajmowane() => zajmowaneMiejsca;
    public DateTime GodzinaPrzyjazdu() => godzinaPrzyjazdu;
}