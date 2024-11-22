#language: nl

@api
Functionaliteit: raadpleeg bewoning in periode levert naam bewoner

  Als provider van de bewoning informatie service
  wil ik dat de volledige naam van de bewoner wordt geleverd
  zodat ik de volledige naam van de bewoner kan leveren aan de consumer van de Bewoning API

  Achtergrond:
    Gegeven adres 'A1' heeft de volgende gegevens
    | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) |
    | 0800                 | 0800000000000001                         |
    En de persoon met burgerservicenummer '000000024' heeft de volgende gegevens
    | voornamen (02.10) | adellijke titel of predicaat (02.20) | voorvoegsel (02.30) | geslachtsnaam (02.40) |
    | Carolina          | BS                                   | Van                 | Naersen               |

  Regel: een persoon is binnen een periode bewoner van een adresseerbaar object als:
  - de van datum van de periode valt op of na datum aanvang adreshouding van de persoon op het adresseerbaar object
  - de tot datum van de periode valt vóór datum aanvang adreshouding van de persoon op het volgende adresseerbaar object

Scenario: naam van de bewoner wordt geleverd bij het raadplegen van bewoning met periode
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
  En heeft de bewoner de volgende 'naam' gegevens
  | naam          | waarde                       |
  | volledigeNaam | Carolina barones Van Naersen |

Scenario: naam van de bewoner wordt geleverd bij het raadplegen van bewoning met peildatum
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
  En heeft de bewoner de volgende 'naam' gegevens
  | naam          | waarde                       |
  | volledigeNaam | Carolina barones Van Naersen |

  Regel: een persoon is binnen een periode mogelijke bewoner van een adresseerbaar object als:
  - de inschrijving datum aanvang adreshouding op het adresseerbaar object (deels) onbekend is, er is hier sprake van een onzerkerheidsperiode
  - voor dat deel van de periode die in de onzekerheidsperiode van de gevraagde adreshouding ligt is de bewoner een mogelijke bewoner

Scenario: naam van de mogelijke bewoner wordt geleverd bij het raadplegen van bewoning met periode
  Gegeven de persoon is ingeschreven op adres 'A1' met de volgende gegevens
  | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
  | 0800                              | 20100000                           |
  Als bewoningen wordt gezocht met de volgende parameters
  | naam                             | waarde             |
  | type                             | BewoningMetPeriode |
  | datumVan                         | 2010-09-01         |
  | datumTot                         | 2014-08-01         |
  | adresseerbaarObjectIdentificatie | 0800000000000001   |
  Dan heeft de response een bewoning met de volgende gegevens
  | naam                             | waarde                    |
  | periode                          | 2010-09-01 tot 2011-01-01 |
  | adresseerbaarObjectIdentificatie | 0800000000000001          |
  En heeft de bewoning een mogelijke bewoner met de volgende gegevens
  | burgerservicenummer | naam.volledigeNaam           |
  | 000000024           | Carolina barones Van Naersen |
  Dan heeft de response een bewoning met de volgende gegevens
  | naam                             | waarde                    |
  | periode                          | 2011-01-01 tot 2014-08-01 |
  | adresseerbaarObjectIdentificatie | 0800000000000001          |
  En heeft de bewoning een bewoner met de volgende gegevens
  | burgerservicenummer | naam.volledigeNaam           |
  | 000000024           | Carolina barones Van Naersen |

Scenario: naam van de mogelijke bewoner wordt geleverd bij het raadplegen van bewoning met peildatum
  Gegeven de persoon is ingeschreven op adres 'A1' met de volgende gegevens
  | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
  | 0800                              | 201000000                          |
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
  | burgerservicenummer | naam.volledigeNaam           |
  | 000000024           | Carolina barones Van Naersen |

Regel: indicatie geheim met waarde hoger dan 0 wordt ongevraagd meegeleverd

  Abstract Scenario: een persoon met indicatie geheim <waarde>, naam van de bewoner wordt geleverd bij het raadplegen van bewoning met periode
    Gegeven de persoon is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
    | 0800                              | 20100818                           |
    En de persoon heeft de volgende 'inschrijving' gegevens
    | naam                     | waarde   |
    | indicatie geheim (70.10) | <waarde> |
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
    | burgerservicenummer | geheimhoudingPersoonsgegevens |
    | 000000024           | true                          |
    En heeft de bewoner de volgende 'naam' gegevens
    | naam          | waarde                       |
    | volledigeNaam | Carolina barones Van Naersen |

    Voorbeelden:
    | waarde |
    | 1      |
    | 2      |
    | 3      |
    | 4      |
    | 5      |
    | 6      |
    | 7      |