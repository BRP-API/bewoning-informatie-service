using Bewoning.Data.Mock.Controllers;
using FluentAssertions;
using Bewoning.Data.Mock.Entities;
using Bewoning.Data.Mock.Generated;
using Bewoning.Data.Mock.Repositories;

namespace Bewoning.Data.Mock.Tests;

public class IsBewonerTests
{
    [Fact]
    public void open_adreshouding_periode_overlapt_opgegeven_periode_niet()
    {
        new Verblijfplaats
        {
            DatumAanvangAdreshouding = "20150808"
        }.IsBewoner(new Periode
        {
            DatumVan = 20150101.ToDateTimeOffset(),
            DatumTot = 20150808.ToDateTimeOffset()
        }).Should().BeFalse();
    }

    [Theory]
    [InlineData(20150808)]
    [InlineData(20151008)]
    public void open_adreshouding_periode_overlapt_opgegeven_periode(long van)
    {
        new Verblijfplaats
        {
            DatumAanvangAdreshouding = "20150808"
        }.IsBewoner(new Periode
        {
            DatumVan = van.ToDateTimeOffset(),
            DatumTot = 20160101.ToDateTimeOffset()
        }).Should().BeTrue();
    }

    [Theory]
    [InlineData("20150800")]
    [InlineData("20150000")]
    [InlineData("00000000")]
    public void onzekerheidsperiode_open_adreshouding_periode_overlapt_opgegeven_periode(string datumAanvang)
    {
        new Verblijfplaats
        {
            DatumAanvangAdreshouding = datumAanvang
        }.IsBewoner(new Periode
        {
            DatumVan = 20150801.ToDateTimeOffset(),
            DatumTot = 20150901.ToDateTimeOffset()
        }).Should().BeFalse();
    }

    [Theory]
    [InlineData("20150800")]
    [InlineData("20150000")]
    [InlineData("00000000")]
    public void onzekerheidsperiode_adreshouding_periode_overlapt_opgegeven_periode(string datumEinde)
    {
        new Verblijfplaats
        {
            DatumAanvangAdreshouding = "20150101",
            DatumEindeAdreshouding = datumEinde
        }.IsBewoner(new Periode
        {
            DatumVan = 20150801.ToDateTimeOffset(),
            DatumTot = 20150901.ToDateTimeOffset()
        }).Should().BeFalse();
    }
}
