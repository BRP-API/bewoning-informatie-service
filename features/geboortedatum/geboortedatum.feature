#language: nl

Functionaliteit: Leveren van de geboortedatum van een (mogelijke) bewoner

  Als consumer van de Bewoning API
  wil ik bij het vragen van de bewoning van een adresseerbaar object ook de geboortedatum van de (mogelijke) bewoners ontvangen
  zodat ik dit niet apart hoef op te vragen

  Achtergrond:
    Gegeven adres 'A1' heeft de volgende gegevens
    | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) |
    | 0800                 | 0800000000000001                         |
    En de persoon met burgerservicenummer '000000024' heeft de volgende gegevens
    | geboortedatum (03.10) |
    | 19791118              |

  Scenario: persoon is bewoner in de gevraagde periode
    Gegeven de persoon is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
    | 0800                              | 20100818                           |
    Als bewoningen wordt gezocht met de volgende parameters
    | naam                             | waarde             |
    | type                             | BewoningMetPeriode |
    | datumVan                         | 2010-09-01         |
    | datumTot                         | 2014-08-01         |
    | adresseerbaarObjectIdentificatie | 0800000000000001   |
    Dan heeft de response een bewoning met de volgende gegevens
    | naam                             | waarde                    |
    | periode                          | 2010-09-01 tot 2014-08-01 |
    | adresseerbaarObjectIdentificatie | 0800000000000001          |
    En heeft de bewoning een bewoner met de volgende gegevens
    | burgerservicenummer |
    | 000000024           |
    En heeft de bewoner de volgende 'geboorte' gegevens
    | naam              | waarde           |
    | datum.datum       | 1979-11-18       |
    | datum.langFormaat | 18 november 1979 |
    | datum.type        | Datum            |

  Scenario: persoon is bewoner op de gevraagde peildatum
    Gegeven de persoon is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
    | 0800                              | 20100818                           |
    Als bewoningen wordt gezocht met de volgende parameters
    | naam                             | waarde               |
    | type                             | BewoningMetPeildatum |
    | peildatum                        | 2010-09-01           |
    | adresseerbaarObjectIdentificatie | 0800000000000001     |
    Dan heeft de response een bewoning met de volgende gegevens
    | naam                             | waarde                    |
    | periode                          | 2010-09-01 tot 2010-09-02 |
    | adresseerbaarObjectIdentificatie | 0800000000000001          |
    En heeft de bewoning een bewoner met de volgende gegevens
    | burgerservicenummer |
    | 000000024           |
    En heeft de bewoner de volgende 'geboorte' gegevens
    | naam              | waarde           |
    | datum.datum       | 1979-11-18       |
    | datum.langFormaat | 18 november 1979 |
    | datum.type        | Datum            |

  Scenario: persoon is mogelijke bewoner in de gevraagde periode
    Gegeven de persoon is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
    | 0800                              | 20100000                           |
    Als bewoningen wordt gezocht met de volgende parameters
    | naam                             | waarde             |
    | type                             | BewoningMetPeriode |
    | datumVan                         | 2010-09-01         |
    | datumTot                         | 2011-01-01         |
    | adresseerbaarObjectIdentificatie | 0800000000000001   |
    Dan heeft de response een bewoning met de volgende gegevens
    | naam                             | waarde                    |
    | periode                          | 2010-09-01 tot 2011-01-01 |
    | adresseerbaarObjectIdentificatie | 0800000000000001          |
    En heeft de bewoning een mogelijke bewoner met de volgende gegevens
    | burgerservicenummer |
    | 000000024           |
    En heeft de mogelijke bewoner de volgende 'geboorte' gegevens
    | naam              | waarde           |
    | datum.datum       | 1979-11-18       |
    | datum.langFormaat | 18 november 1979 |
    | datum.type        | Datum            |

  Scenario: persoon is mogelijke bewoner op de gevraagde peildatum
    Gegeven de persoon is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
    | 0800                              | 20100000                           |
    Als bewoningen wordt gezocht met de volgende parameters
    | naam                             | waarde               |
    | type                             | BewoningMetPeildatum |
    | peildatum                        | 2010-09-01           |
    | adresseerbaarObjectIdentificatie | 0800000000000001     |
    Dan heeft de response een bewoning met de volgende gegevens
    | naam                             | waarde                    |
    | periode                          | 2010-09-01 tot 2010-09-02 |
    | adresseerbaarObjectIdentificatie | 0800000000000001          |
    En heeft de bewoning een mogelijke bewoner met de volgende gegevens
    | burgerservicenummer |
    | 000000024           |
    En heeft de mogelijke bewoner de volgende 'geboorte' gegevens
    | naam              | waarde           |
    | datum.datum       | 1979-11-18       |
    | datum.langFormaat | 18 november 1979 |
    | datum.type        | Datum            |
