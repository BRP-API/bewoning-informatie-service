#language: nl

Functionaliteit: niet leveren van een bewoner met opschorting bijhouding bij het raadplegen van bewoning op peildatum

  Achtergrond:
    Gegeven adres 'A1' heeft de volgende gegevens
    | gemeentecode (92.10) | identificatiecode verblijfplaats (11.80) |
    | 0800                 | 0800010000000001                         |

Regel: personen met een afgevoerde persoonslijst worden niet gezien als bewoner

  Scenario: persoon heeft afgevoerde persoonslijst
    Gegeven de persoon met burgerservicenummer '000000024' is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
    | 0800                              | 20100818                           |
    En de persoon heeft de volgende 'inschrijving' gegevens
    | datum opschorting bijhouding (67.10) | reden opschorting bijhouding (67.20) |
    | 20220829                             | F                                    |
    Als bewoningen wordt gezocht met de volgende parameters
    | naam                             | waarde               |
    | type                             | BewoningMetPeildatum |
    | peildatum                        | 2010-09-01           |
    | adresseerbaarObjectIdentificatie | 0800010000000001     |
    Dan heeft de response 0 bewoningen

Regel: personen op een logisch verwijderde persoonslijst worden niet gezien als bewoner

  Scenario: persoon is opgeschort met reden "W" (wissen)
    Gegeven de persoon met burgerservicenummer '000000024' is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
    | 0800                              | 20100818                           |
    En de persoon heeft de volgende 'inschrijving' gegevens
    | datum opschorting bijhouding (67.10) | reden opschorting bijhouding (67.20) |
    | 20220829                             | W                                    |
    Als bewoningen wordt gezocht met de volgende parameters
    | naam                             | waarde               |
    | type                             | BewoningMetPeildatum |
    | peildatum                        | 2010-09-01           |
    | adresseerbaarObjectIdentificatie | 0800010000000001     |
    Dan heeft de response 0 bewoningen

Regel: personen met opschorting bijhouding met aanduiding ongelijk aan "F" of "W" worden na datum opschorting bijhouding niet gezien als bewoner

  Abstract Scenario: persoon is opgeschort met reden "<reden opschorting bijhouding>" (<reden opschorting omschrijving>) en peildatum ligt vóór datum opschorting bijhouding
    Gegeven de persoon met burgerservicenummer '000000024' is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
    | 0800                              | 20100818                           |
    En de persoon heeft de volgende 'inschrijving' gegevens
    | datum opschorting bijhouding (67.10) | reden opschorting bijhouding (67.20) |
    | 20220829                             | <reden opschorting bijhouding>       |
    Als bewoningen wordt gezocht met de volgende parameters
    | naam                             | waarde               |
    | type                             | BewoningMetPeildatum |
    | peildatum                        | 2022-08-28           |
    | adresseerbaarObjectIdentificatie | 0800010000000001     |
    Dan heeft de response een bewoning met de volgende gegevens
    | naam                             | waarde                    |
    | periode                          | 2022-08-28 tot 2022-08-29 |
    | adresseerbaarObjectIdentificatie | 0800010000000001          |
    En heeft de bewoning een bewoner met de volgende gegevens
    | burgerservicenummer |
    | 000000024           |

    Voorbeelden:
    | reden opschorting bijhouding | reden opschorting omschrijving |
    | O                            | overlijden                     |
    | E                            | emigratie                      |
    | M                            | ministerieel besluit           |
    | R                            | pl is aangelegd in de rni      |
    | .                            | onbekend                       |

  Abstract Scenario: persoon is opgeschort met reden "<reden opschorting bijhouding>" (<reden opschorting omschrijving>) en <scenario>
    Gegeven de persoon met burgerservicenummer '000000024' is ingeschreven op adres 'A1' met de volgende gegevens
    | gemeente van inschrijving (09.10) | datum aanvang adreshouding (10.30) |
    | 0800                              | 20100818                           |
    En de persoon heeft de volgende 'inschrijving' gegevens
    | datum opschorting bijhouding (67.10) | reden opschorting bijhouding (67.20) |
    | 20220829                             | <reden opschorting bijhouding>       |
    Als bewoningen wordt gezocht met de volgende parameters
    | naam                             | waarde               |
    | type                             | BewoningMetPeildatum |
    | peildatum                        | <peildatum>          |
    | adresseerbaarObjectIdentificatie | 0800010000000001     |
    Dan heeft de response 0 bewoningen

    Voorbeelden:
    | reden opschorting bijhouding | reden opschorting omschrijving | peildatum  | periode                   | scenario                                       |
    | O                            | overlijden                     | 2022-08-29 | 2022-08-29 tot 2022-08-30 | peildatum ligt op datum opschorting bijhouding |
    | O                            | overlijden                     | 2022-09-01 | 2022-09-01 tot 2022-09-02 | peildatum ligt na datum opschorting bijhouding |
    | E                            | emigratie                      | 2022-08-29 | 2022-08-29 tot 2022-08-30 | peildatum ligt op datum opschorting bijhouding |
    | E                            | emigratie                      | 2022-09-01 | 2022-09-01 tot 2022-09-02 | peildatum ligt na datum opschorting bijhouding |
    | M                            | ministerieel besluit           | 2022-08-29 | 2022-08-29 tot 2022-08-30 | peildatum ligt op datum opschorting bijhouding |
    | M                            | ministerieel besluit           | 2022-09-01 | 2022-09-01 tot 2022-09-02 | peildatum ligt na datum opschorting bijhouding |
    | R                            | pl is aangelegd in de rni      | 2022-08-29 | 2022-08-29 tot 2022-08-30 | peildatum ligt op datum opschorting bijhouding |
    | R                            | pl is aangelegd in de rni      | 2022-09-01 | 2022-09-01 tot 2022-09-02 | peildatum ligt na datum opschorting bijhouding |
    | .                            | onbekend                       | 2022-08-29 | 2022-08-29 tot 2022-08-30 | peildatum ligt op datum opschorting bijhouding |
    | .                            | onbekend                       | 2022-09-01 | 2022-09-01 tot 2022-09-02 | peildatum ligt na datum opschorting bijhouding |
