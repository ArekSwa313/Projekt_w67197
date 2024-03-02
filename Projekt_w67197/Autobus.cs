using System;

public class Autobus : Pojazd
{
    public Autobus(string numer, DateTime przyjazd) : base(numer, 4, przyjazd) { }
    public override string TypPojazdu() => "Autobus";
}
