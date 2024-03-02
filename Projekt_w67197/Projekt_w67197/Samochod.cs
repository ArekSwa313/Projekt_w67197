using System;

public class Samochod : Pojazd
{
    public Samochod(string numer, DateTime przyjazd) : base(numer, 2, przyjazd) { }
    public override string TypPojazdu() => "Samochod";
}
