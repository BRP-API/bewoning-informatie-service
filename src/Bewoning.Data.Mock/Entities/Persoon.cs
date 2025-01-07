namespace Bewoning.Data.Mock.Entities;

public class Persoon
{
    public string? BurgerserviceNummer { get; set; }
    public Verblijfplaats? Verblijfplaats { get; set; }
    public int? GeheimhoudingPersoonsgegevens { get; set; }
    public Naam? Naam { get; set; }
    public Geboorte? Geboorte { get; set; }
}
