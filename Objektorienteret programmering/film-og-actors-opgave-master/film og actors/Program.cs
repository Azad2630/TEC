class Program
{
    static void Main()
    {
        // Opret skuespillere
        Skuespiller skuespiller1 = new Skuespiller("Skuespiller 1");
        Skuespiller skuespiller2 = new Skuespiller("Skuespiller 2");
        Skuespiller skuespiller3 = new Skuespiller("Skuespiller 3");
        Skuespiller skuespiller4 = new Skuespiller("Skuespiller 4");
        Skuespiller skuespiller5 = new Skuespiller("Skuespiller 5");

        // Opret film og tildel skuespillere til dem
        Film film1 = new Film("Film 1");
        film1.TilføjSkuespiller(skuespiller1);
        film1.TilføjSkuespiller(skuespiller2);
        film1.TilføjSkuespiller(skuespiller3);

        Film film2 = new Film("Film 2");
        film2.TilføjSkuespiller(skuespiller2);
        film2.TilføjSkuespiller(skuespiller4);

        Film film3 = new Film("Film 3");
        film3.TilføjSkuespiller(skuespiller1);
        film3.TilføjSkuespiller(skuespiller5);

        // Vis film med skuespillere
        Console.WriteLine("Film med skuespillere:");
        Console.WriteLine(film1);
        Console.WriteLine(film2);
        Console.WriteLine(film3);

        // Vis skuespillere og hvilke film de har været med i
        Console.WriteLine("\nSkuespillere og deres film:");
        Console.WriteLine(skuespiller1);
        Console.WriteLine(skuespiller2);
        Console.WriteLine(skuespiller3);
        Console.WriteLine(skuespiller4);
        Console.WriteLine(skuespiller5);
    }
}

class Skuespiller
{
    public string Navn { get; }
    public List<Film> FilmMedvirketI { get; }

    public Skuespiller(string navn)
    {
        Navn = navn;
        FilmMedvirketI = new List<Film>();
    }

    public void TilføjFilm(Film film)
    {
        FilmMedvirketI.Add(film);
    }

    public override string ToString()
    {
        string filmTitler = string.Join(", ", FilmMedvirketI.Select(film => film.Titel));
        return $"{Navn} har medvirket i følgende film: {filmTitler}";
    }
}


class Film
{
    public string Titel { get; }
    public List<Skuespiller> Skuespillere { get; }

    public Film(string titel)
    {
        Titel = titel;
        Skuespillere = new List<Skuespiller>();
    }

    public void TilføjSkuespiller(Skuespiller skuespiller)
    {
        Skuespillere.Add(skuespiller);
        skuespiller.TilføjFilm(this);
    }

    public override string ToString()
    {
        return $"{Titel} har følgende skuespillere: {string.Join(", ", Skuespillere)}";
    }
}
