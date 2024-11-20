namespace Bewoning.Informatie.Service.Mappers
{
    public static class VerblijfplaatsInOnderzoekMapper
    {
        public static bool MapInOnderzoek(this string inOnderzoek)
        {
            return inOnderzoek switch
            {
                "080000" or
                "081000" or
                "081010" or
                "081030" or
                "081100" or
                "081180" or
                "580000" or
                "581000" or
                "581010" or
                "581030" or
                "581100" or
                "581180" => true,
                _ => false
            };
        }
    }
}
