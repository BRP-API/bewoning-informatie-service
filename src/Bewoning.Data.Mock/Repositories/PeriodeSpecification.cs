using Bewoning.Data.Mock.Entities;
using Bewoning.Data.Mock.Repositories;
using Brp.Shared.Infrastructure.Utils;
using System.Linq.Expressions;

namespace Bewoning.Data.Mock.Repositories;

public class PeriodeSpecification : Specification<Persoon>
{
    private readonly DateTimeOffset _datumVan;
    private readonly DateTimeOffset _datumTot;

    public PeriodeSpecification(string datumVan, string datumTot)
    {
        _datumVan = datumVan.ToDateTimeOffset();
        _datumTot = datumTot.ToDateTimeOffset();
    }

    public override Expression<Func<Persoon, bool>> ToExpression()
    {
        return persoon => persoon != null &&
                          persoon.Verblijfplaats != null &&
                          persoon.Verblijfplaats.DatumAanvangAdreshouding != null &&
                          _datumTot.ToNumber() >= persoon.Verblijfplaats.DatumAanvangAdreshouding.ToNumber() &&
                          (persoon.Verblijfplaats.DatumEindeAdreshouding == null
                           ||
                           persoon.Verblijfplaats.DatumEindeAdreshouding != null &&
                           _datumVan.ToNumber() < persoon.Verblijfplaats.DatumEindeAdreshouding.ToNumber()

                          );
    }
}
