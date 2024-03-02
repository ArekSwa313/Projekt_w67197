using System;

public class Motocykl : Pojazd
{
    public Motocykl(string numer, DateTime przyjazd) : base(numer, 1, przyjazd) { }
    public override string TypPojazdu() => "Motocykl";
}