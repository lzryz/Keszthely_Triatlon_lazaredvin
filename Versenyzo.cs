namespace Keszthely_Triatlon_lazaredvin;

internal class Versenyzo
{
    public string Nev { get; set; }
    public int SzuletesEv { get; set; }
    public int Rajtszam { get; set; }
    public char Neme { get; set; }
    public string Kategoria { get; set; }
    public TimeSpan UszasIdeje { get; set; }
    public TimeSpan ElsoDepo { get; set; }
    public TimeSpan KerekparozasIdeje { get; set; }
    public TimeSpan MasodikDepo { get; set; }
    public TimeSpan FutasIdeje { get; set; }
    public Versenyzo(string nev, int szuletesEv, int rajtszam, char neme, string kategoria,
                     TimeSpan uszas, TimeSpan elsoDepo, TimeSpan kerekparozas, TimeSpan masodikDepo, TimeSpan futas)
    {
        Nev = nev;
        SzuletesEv = szuletesEv;
        Rajtszam = rajtszam;
        Neme = neme;
        Kategoria = kategoria;
        UszasIdeje = uszas;
        ElsoDepo = elsoDepo;
        KerekparozasIdeje = kerekparozas;
        MasodikDepo = masodikDepo;
        FutasIdeje = futas;
    }
    public TimeSpan TeljesIdo()
    {
        return UszasIdeje + ElsoDepo + KerekparozasIdeje + MasodikDepo + FutasIdeje;
    }
    public override string ToString()
    {
        return $"{Nev};{SzuletesEv};{Rajtszam};{Neme};{Kategoria};" +
               $"{UszasIdeje:hh\\:mm\\:ss};{ElsoDepo:hh\\:mm\\:ss};{KerekparozasIdeje:hh\\:mm\\:ss};{MasodikDepo:hh\\:mm\\:ss};{FutasIdeje:hh\\:mm\\:ss}";
    }
}


