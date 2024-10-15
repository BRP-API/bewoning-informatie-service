using Bewoning.Data.Mock.Entities;
using Bewoning.Data.Mock.Generated;

namespace Bewoning.Data.Mock.Repositories;

public static class PersoonQueryExtensions
{
    public static Specification<Persoon> ToSpecification(this BewoningMetPeildatum query)
    {
        return new AdresseerbaarObjectIdentificatieSpecification(query.AdresseerbaarObjectIdentificatie!)
            .And(new PeildatumSpecification(query.Peildatum!))
            ;
    }

    public static Specification<Persoon> ToSpecification(this BewoningMetPeriode query)
    {
        return new AdresseerbaarObjectIdentificatieSpecification(query.AdresseerbaarObjectIdentificatie!)
            .And(new PeriodeSpecification(query.DatumVan!, query.DatumTot!))
            ;
    }
}
