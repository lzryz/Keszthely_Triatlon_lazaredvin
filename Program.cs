using Keszthely_Triatlon_lazaredvin;
using System.Globalization;
using System.Text;


List<Versenyzo> versenyzok = new List<Versenyzo>();

using (StreamReader sr = new StreamReader("..\\..\\..\\src\\forras.txt", Encoding.UTF8))
{
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine();

        var parts = line.Split(';');

        string nev = parts[0];
        int szuletesEv = int.Parse(parts[1]);
        int rajtszam = int.Parse(parts[2]);
        char neme = parts[3][0];
        string kategoria = parts[4];

        TimeSpan uszas = TimeSpan.ParseExact(parts[5], "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
        TimeSpan elsoDepo = TimeSpan.ParseExact(parts[6], "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
        TimeSpan kerekparozas = TimeSpan.ParseExact(parts[7], "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
        TimeSpan masodikDepo = TimeSpan.ParseExact(parts[8], "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
        TimeSpan futas = TimeSpan.ParseExact(parts[9], "hh\\:mm\\:ss", CultureInfo.InvariantCulture);

        var versenyzo = new Versenyzo(nev, szuletesEv, rajtszam, neme, kategoria, uszas, elsoDepo, kerekparozas, masodikDepo, futas);
        versenyzok.Add(versenyzo);
    }
}

KiirSzamolas(versenyzok);
    

static void KiirSzamolas(List<Versenyzo> versenyzok)
{
    Console.WriteLine($"1. feladat: Versenyt befejező versenyzők száma: {versenyzok.Count}");

    var elitVersenyzok = versenyzok.Count(v => v.Kategoria == "elit");
    Console.WriteLine($"2. feladat: Elit kategóriában versenyzők száma: {elitVersenyzok}");

    var noiVersenyzok = versenyzok.Where(v => v.Neme == 'n');
    double atlagEletkor = noiVersenyzok.Average(v => DateTime.Now.Year - v.SzuletesEv);
    Console.WriteLine($"3. feladat: Női versenyzők átlagéletkora: {atlagEletkor:F2}");

    double osszesKerekparozas = versenyzok.Sum(v => v.KerekparozasIdeje.TotalHours);
    Console.WriteLine($"4. feladat: Összes kerékpározás ideje (óra): {osszesKerekparozas:F2}");

    var elitJuniorUszas = versenyzok.Where(v => v.Kategoria == "elit junior");
    if (elitJuniorUszas.Any())
    {
        double atlagUszas = elitJuniorUszas.Average(v => v.UszasIdeje.TotalSeconds);
        Console.WriteLine($"5. feladat: Átlagos úszási idő elit junior kategóriában: {TimeSpan.FromSeconds(atlagUszas):hh\\:mm\\:ss}");
    }

    var ferfiGyoztes = versenyzok.Where(v => v.Neme == 'f').OrderBy(v => v.TeljesIdo()).First();
    Console.WriteLine($"6. feladat: Férfi győztes: {ferfiGyoztes.Nev}");

    var korkategoriak = versenyzok.GroupBy(v => v.Kategoria);
    Console.WriteLine("7. feladat: Korkategóriánkénti versenyzők száma:");
    foreach (var kategoria in korkategoriak)
    {
        Console.WriteLine($"\t{kategoria.Key}: {kategoria.Count()}");
    }

    Console.WriteLine("8. feladat: Korkategóriánkénti átlag depóban töltött idő:");
    foreach (var kategoria in korkategoriak)
    {
        double atlagDepo = kategoria.Average(v => (v.ElsoDepo + v.MasodikDepo).TotalSeconds);
        Console.WriteLine($"\t{kategoria.Key}: {TimeSpan.FromSeconds(atlagDepo):hh\\:mm\\:ss}");
    }
}