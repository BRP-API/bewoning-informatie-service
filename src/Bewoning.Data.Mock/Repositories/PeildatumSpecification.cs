using Bewoning.Data.Mock.Entities;
using Bewoning.Data.Mock.Repositories;
using Brp.Shared.Infrastructure.Utils;
using System.Linq.Expressions;

namespace Bewoning.Data.Mock.Repositories;

public class PeildatumSpecification : Specification<Persoon>
{
    private readonly DateTimeOffset _peildatum;

    public PeildatumSpecification(string peildatum)
    {
        _peildatum = peildatum.ToDateTimeOffset();
    }

    public override Expression<Func<Persoon, bool>> ToExpression()
    {
        return persoon => persoon != null &&
                          persoon.Verblijfplaats != null &&
                          persoon.Verblijfplaats.DatumAanvangAdreshouding != null &&
                          persoon.Verblijfplaats.DatumAanvangAdreshouding.ToNumber() <= _peildatum.ToNumber() &&
                          (persoon.Verblijfplaats.DatumEindeAdreshouding == null
                           ||
                           persoon.Verblijfplaats.DatumEindeAdreshouding != null &&
                            persoon.Verblijfplaats.DatumEindeAdreshouding.ToNumber() > _peildatum.ToNumber()

                          );
    }
}
