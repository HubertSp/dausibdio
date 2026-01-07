using ZelmetErpSpec;

var spec = SpecificationFactory.Build();

Console.WriteLine($"Spec: {spec.Overview.Name}");
Console.WriteLine($"Version: {spec.Metadata.Version} (created {spec.Metadata.CreatedAt:yyyy-MM-dd}, modified {spec.Metadata.ModifiedAt:yyyy-MM-dd})");
Console.WriteLine($"Authors: {string.Join(", ", spec.Metadata.Authors)}");
Console.WriteLine();

Console.WriteLine("Key modules:");
foreach (var module in spec.Modules)
{
    Console.WriteLine($"- {module.Code}: {module.Name}");
}

Console.WriteLine();
Console.WriteLine($"Actors: {spec.Actors.Count}");
Console.WriteLine($"Business processes: {spec.BusinessProcesses.Count}");
Console.WriteLine($"Functional requirements: {spec.FunctionalRequirements.Count}");
Console.WriteLine($"Non-functional requirements: {spec.NonFunctionalRequirements.Count}");

internal static class SpecificationFactory
{
    public static SpecificationDocument Build()
    {
        var metadata = new SpecificationMetadata(
            "1.0",
            new DateOnly(2025, 12, 21),
            new DateOnly(2026, 1, 6),
            new List<string> { "Bastian Walczak", "Karol Urbaniak", "Huber Spychalski" });

        var overview = new SystemOverview(
            "Żelmet ERP",
            "Zintegrowany system zarządzania produkcją i zamówieniami dla firmy Żelmet.",
            new List<string>
            {
                "Moduł Zarządzania Zleceniami",
                "Moduł Planowania Produkcji",
                "Moduł Monitorowania Wydajności (MES)",
                "Moduł Logistyki i Magazynu",
                "Moduł Finansowo-Analityczny"
            },
            new List<string>
            {
                "Operatorzy maszyn",
                "Kadra biurowa",
                "Kierownictwo"
            },
            new List<string>
            {
                "Zwiększenie kontroli nad kosztami i rentownością",
                "Poprawa efektywności i wydajności produkcji",
                "Wzrost terminowości i jakości obsługi",
                "Odzyskanie stabilności rynkowej",
                "Uporządkowanie obiegu informacji"
            });

        var modules = new List<Module>
        {
            new(ModuleCode.M, "Magazyn", "Przyjęcia, wydania, stany i lokalizacje materiałów."),
            new(ModuleCode.P, "Produkcja", "Zlecenia produkcyjne, meldowanie pracy, zużycie materiału."),
            new(ModuleCode.U, "Utrzymanie ruchu", "Awarie, przeglądy, części zamienne."),
            new(ModuleCode.D, "Dostawy i zakupy", "Zamówienia do dostawców oraz terminy dostaw."),
            new(ModuleCode.Q, "Jakość", "Kontrola jakości, reklamacje i niezgodności."),
            new(ModuleCode.R, "Rozliczenia / księgowość", "Dokumenty kosztowe, faktury, rozliczenia zleceń."),
            new(ModuleCode.Z, "Zarząd i analizy", "Raporty, KPI i dashboard."),
            new(ModuleCode.A, "Administracja systemem", "Użytkownicy, uprawnienia i konfiguracja."),
            new(ModuleCode.DOD, "Dane podstawowe", "Kartoteki materiałów, produktów, maszyn i kontrahentów.")
        };

        var actors = new List<Actor>
        {
            new(
                "A01",
                "Operator Maszyn",
                "Pracownik hali odpowiedzialny za fizyczną obróbkę metali.",
                new List<string>
                {
                    "Przeglądanie przypisanych zadań produkcyjnych",
                    "Rejestrowanie czasu pracy nad elementem",
                    "Zgłaszanie wykonania kontroli jakości"
                },
                new List<string>
                {
                    "Imię i nazwisko",
                    "Identyfikator operatora",
                    "Specjalizacja/Uprawnienia do maszyn",
                    "Status bieżącego zadania"
                }),
            new(
                "A02",
                "Pracownik Biurowy",
                "Administracja, kontakt z klientami i logistyka surowców.",
                new List<string>
                {
                    "Rejestrowanie zleceń od kontrahentów",
                    "Planowanie harmonogramu produkcji",
                    "Koordynacja logistyki",
                    "Wystawianie faktur i rozliczanie płatności"
                },
                new List<string>
                {
                    "Imię i nazwisko",
                    "Identyfikator pracownika",
                    "Dział",
                    "Historia kontaktów z kontrahentami"
                }),
            new(
                "A03",
                "Kierownik",
                "Zarządzanie wydajnością, kosztami i stabilnością firmy.",
                new List<string>
                {
                    "Analiza wydajności pracowników i czasu pracy maszyn",
                    "Monitorowanie obrotów i kosztów",
                    "Zatwierdzanie raportów statystycznych i podatkowych"
                },
                new List<string>
                {
                    "Imię i nazwisko",
                    "Identyfikator menedżera",
                    "Poziom uprawnień do danych finansowych",
                    "Zestawienia KPI"
                }),
            new(
                "A04",
                "Klient/Kontrahent",
                "Podmiot zewnętrzny zamawiający produkty lub usługi.",
                new List<string>
                {
                    "Przesyłanie zapytań ofertowych i zamówień",
                    "Odbieranie produktów i potwierdzanie dostaw",
                    "Dokonywanie płatności"
                },
                new List<string>
                {
                    "Nazwa firmy",
                    "NIP / Dane do faktury",
                    "Rodzaj kontraktu",
                    "Saldo rozliczeń"
                })
        };

        var businessObjects = new List<BusinessObject>
        {
            new(
                "O01",
                "Zlecenie",
                "Zamówienie na obróbkę metali złożone przez klienta.",
                new List<string>
                {
                    "Typ zlecenia",
                    "Status",
                    "Data przyjęcia i termin realizacji",
                    "Specyfikacja techniczna",
                    "Ilość sztuk"
                },
                new List<string>
                {
                    "Klient/Kontrahent (A04)",
                    "Operator Maszyn (A01)",
                    "Zadanie Produkcyjne (O02)"
                }),
            new(
                "O02",
                "Zadanie Produkcyjne",
                "Operacja technologiczna do wykonania na hali produkcyjnej.",
                new List<string>
                {
                    "Rodzaj operacji",
                    "Czas rozpoczęcia i zakończenia",
                    "Stanowisko/Maszyna",
                    "Wynik kontroli jakości"
                },
                new List<string>
                {
                    "Zlecenie (O01)",
                    "Operator Maszyn (A01)"
                }),
            new(
                "O03",
                "Surowiec",
                "Materiały metalowe niezbędne do rozpoczęcia produkcji.",
                new List<string>
                {
                    "Rodzaj materiału",
                    "Ilość na stanie",
                    "Jednostka miary",
                    "Koszt zakupu"
                },
                new List<string>
                {
                    "Dostawca (A04)"
                }),
            new(
                "O04",
                "Faktura",
                "Dokument rozliczeniowy za wykonane usługi lub produkty.",
                new List<string>
                {
                    "Numer dokumentu",
                    "Kwota netto/brutto",
                    "Termin płatności",
                    "Status płatności"
                },
                new List<string>
                {
                    "Klient/Kontrahent (A04)",
                    "Zlecenie (O01)"
                })
        };

        var businessProcesses = new List<BusinessProcess>
        {
            new(
                "BP01",
                "Realizacja stałego kontraktu (produkcja seryjna)",
                "Masowa produkcja dla branży motoryzacyjnej.",
                new List<string> { "Klient", "Kadra biurowa", "Operatorzy maszyn", "System" },
                new List<string>
                {
                    "System generuje plan produkcji na podstawie harmonogramu kontraktu.",
                    "Pracownik biurowy zatwierdza listę zadań.",
                    "Operatorzy realizują procesy obróbki zgodnie z priorytetami.",
                    "System monitoruje czas pracy maszyn i ludzi w czasie rzeczywistym.",
                    "Gotowe części przechodzą kontrolę jakości, są pakowane i wysyłane.",
                    "System przygotowuje dane do rozliczenia kwartalnego."
                }),
            new(
                "BP02",
                "Obsługa zleceń jednostkowych i prototypowych",
                "Realizacja nieregularnych zamówień dla mniejszych firm.",
                new List<string> { "Klient", "Kadra biurowa", "Operator maszyn", "System" },
                new List<string>
                {
                    "Pracownik biurowy rejestruje zapytanie w module zleceń.",
                    "System wspiera przygotowanie wyceny indywidualnej.",
                    "Zadanie jest przypisane do operatora o wysokich kwalifikacjach.",
                    "Operator wykonuje obróbkę i kontrolę jakości.",
                    "System generuje fakturę rozliczaną po zamówieniu."
                }),
            new(
                "BP03",
                "Zarządzanie zaopatrzeniem i zapasami surowców",
                "Uporządkowanie logistyki i dostaw.",
                new List<string> { "Kadra biurowa", "Lokalny dostawca", "System" },
                new List<string>
                {
                    "System identyfikuje niskie stany magazynowe.",
                    "Pracownik biurowy wysyła zapytanie ofertowe do dostawców.",
                    "Po dostarczeniu materiału dane dostawy trafiają do systemu.",
                    "System aktualizuje bazę kosztów surowców.",
                    "Dane o wydatkach trafiają do miesięcznego zestawienia kosztów."
                })
        };

        var functionalRequirements = new List<FunctionalRequirement>
        {
            new("USK1-01", "Magazynier", "M", "Szybkie wyszukiwanie materiału po numerze, nazwie lub kodzie kreskowym."),
            new("USK1-02", "Magazynier", "M", "Przyjmowanie dostaw materiału poprzez formularz podobny do tabeli Excela."),
            new("USK1-03", "Magazynier", "M", "Rejestrowanie wydań materiału na konkretne zlecenie produkcyjne."),
            new("USK1-04", "Magazynier", "M", "Podgląd stanów magazynowych w sztukach, kg i wartościach."),
            new("USK1-05", "Magazynier", "M", "Szybkie korygowanie stanu magazynu (inwentaryzacja, pomyłka)."),
            new("USK1-06", "Magazynier", "M", "Eksport i wydruk prostych list magazynowych."),
            new("USK1-07", "Magazynier", "M", "Historia ruchów dla danego materiału."),
            new("USK2-01", "Kierownik magazynu", "M", "Ustalanie minimalnych stanów magazynowych."),
            new("USK2-02", "Kierownik magazynu", "M/Z", "Raport rotacji materiałów."),
            new("USK2-03", "Kierownik magazynu", "M/D", "Powiązanie materiałów z zamówieniami do dostawców."),
            new("USK2-04", "Kierownik magazynu", "M", "Blokowanie wydania materiału z powodów jakościowych."),
            new("USK2-05", "Kierownik magazynu", "M/Z", "Dashboard z kluczowymi wskaźnikami magazynu."),
            new("USK3-01", "Operator", "P", "Lista przydzielonych zleceń produkcyjnych na stanowisku."),
            new("USK3-02", "Operator", "P", "Meldowanie rozpoczęcia i zakończenia pracy nad zleceniem."),
            new("USK3-03", "Operator", "P", "Wprowadzanie ilości sztuk dobrych i braków."),
            new("USK3-04", "Operator", "P/U", "Zgłoszenie awarii maszyny z poziomu zlecenia."),
            new("USK3-05", "Operator", "P", "Podgląd rysunku lub instrukcji technologicznej."),
            new("USK3-06", "Operator", "P", "Duże przyciski z prostymi opisami i kolorami."),
            new("USK4-01", "Kierownik produkcji", "P/Z", "Tworzenie i modyfikacja planu produkcji."),
            new("USK4-02", "Kierownik produkcji", "P", "Podgląd postępu zleceń w czasie zbliżonym do rzeczywistego."),
            new("USK4-03", "Kierownik produkcji", "P/M", "Podgląd dostępności materiałów dla planowanych zleceń."),
            new("USK4-04", "Kierownik produkcji", "P/Q", "Analiza przyczyn braków i reklamacji."),
            new("USK4-05", "Kierownik produkcji", "P/Z", "Raport wydajności maszyn i brygad."),
            new("USK4-06", "Kierownik produkcji", "P", "Drukowanie lub eksport list zadań na zmianę."),
            new("USK5-01", "Inżynier utrzymania ruchu", "U", "Rejestrowanie awarii maszyn wraz z przyczyną i czasem usunięcia."),
            new("USK5-02", "Inżynier utrzymania ruchu", "U", "Planowanie przeglądów okresowych maszyn."),
            new("USK5-03", "Inżynier utrzymania ruchu", "U/M", "Podgląd stanów części zamiennych w magazynie UR."),
            new("USK5-04", "Inżynier utrzymania ruchu", "U/P", "Historia awarii maszyny wraz z powiązanymi zleceniami."),
            new("USK5-05", "Inżynier utrzymania ruchu", "U/Z", "Raporty MTBF/MTTR."),
            new("USK6-01", "Kierownik rozliczeń", "R/P", "Przypisanie kosztów materiału i czasu pracy do zlecenia."),
            new("USK6-02", "Kierownik rozliczeń", "R/Z", "Raport marżowości zleceń."),
            new("USK6-03", "Kierownik rozliczeń", "R/M/D", "Wgląd w faktury zakupowe powiązane z dostawami."),
            new("USK6-04", "Kierownik rozliczeń", "R", "Definiowanie schematów rozliczania kosztów pośrednich."),
            new("USK6-05", "Kierownik rozliczeń", "R/Z", "Eksport danych do systemu finansowo-księgowego."),
            new("USK7-01", "Księgowa", "R", "Wprowadzanie i księgowanie dokumentów kosztowych powiązanych z dostawami."),
            new("USK7-02", "Księgowa", "R", "Generowanie zestawień kosztów wg kont, zleceń i działów."),
            new("USK7-03", "Księgowa", "R", "Kontrola stawek VAT i kont księgowych."),
            new("USK7-04", "Księgowa", "R", "Eksport danych do arkusza kalkulacyjnego."),
            new("USK7-05", "Księgowa", "R", "Podgląd powiązań między dokumentem a dostawą, magazynem i zleceniem."),
            new("USA8-01", "Administrator", "A", "Zakładanie kont użytkowników i przypisywanie ról."),
            new("USA8-02", "Administrator", "A", "Definiowanie uprawnień na poziomie modułów i funkcji."),
            new("USA8-03", "Administrator", "A", "Blokowanie i archiwizowanie kont pracowników."),
            new("USA8-04", "Administrator", "A", "Konfiguracja słowników systemu."),
            new("USA8-05", "Administrator", "A", "Dostęp do logów zdarzeń."),
            new("USK9-01", "Kontroler jakości", "Q/P", "Rejestrowanie wyników kontroli dla partii produktów."),
            new("USK9-02", "Kontroler jakości", "Q/P", "Oznaczanie partii jako OK, warunkowo lub do złomowania."),
            new("USK9-03", "Kontroler jakości", "Q/Z", "Analiza powtarzających się niezgodności."),
            new("USK9-04", "Kontroler jakości", "Q/R", "Rejestrowanie kosztów braków i reklamacji."),
            new("USK10-01", "Specjalista ds. zakupów", "D/M", "Lista materiałów poniżej minimum."),
            new("USK10-02", "Specjalista ds. zakupów", "D", "Rejestrowanie zamówień do dostawców i terminów dostaw."),
            new("USK10-03", "Specjalista ds. zakupów", "D/R", "Porównywanie cen i terminów u dostawców."),
            new("USK10-04", "Specjalista ds. zakupów", "D/Z", "Raporty zakupów wg dostawców i materiałów."),
            new("USK11-01", "Właściciel", "Z", "Prosty widok kluczowych wskaźników biznesowych."),
            new("USK11-02", "Właściciel", "Z", "Wydruk prostych raportów miesięcznych w PDF."),
            new("USK11-03", "Właściciel", "Z/P/R", "Wskazanie najbardziej dochodowych produktów i klientów."),
            new("USK11-04", "Właściciel", "Z", "Przegląd trendów miesięcznych i rocznych."),
            new("US-DOD-01", "Użytkownik", "DOD", "Przeglądanie i edycja kartotek materiałów, produktów, maszyn i kontrahentów."),
            new("US-DOD-02", "Użytkownik", "DOD/M/P", "Współdzielenie danych podstawowych między modułami magazynu i produkcji."),
            new("US-DOD-03", "Administrator", "DOD/A", "Definiowanie słowników systemowych."),
            new("US-DOD-04", "Użytkownik", "DOD", "Historia zmian danych podstawowych."),
            new("US-DOD-05", "Kierownik", "DOD/Z", "Raport poprawności danych (puste pola, duplikaty)."),
            new("US-DOD-06", "Użytkownik rozliczeń", "DOD/R/P", "Spójność danych kosztowych i materiałowych."),
            new("US-DOD-07", "Użytkownik", "DOD/M/D", "Import danych podstawowych z pliku CSV/XLSX.")
        };

        var nonFunctionalRequirements = new List<NonFunctionalRequirement>
        {
            new(
                "NFR01",
                "Wydajność",
                "Kluczowe akcje użytkownika mają odpowiadać w czasie do 3 sekund przy 50 aktywnych użytkownikach.",
                new List<string>
                {
                    "Czas generowania kwartalnego raportu rozliczeniowego do 15 sekund przy obrocie 5 500 000 zł."
                }),
            new(
                "NFR02",
                "Bezpieczeństwo",
                "Kontrola dostępu oparta na rolach (RBAC).",
                new List<string>
                {
                    "Hasła min. 8 znaków, jedna cyfra i jedna wielka litera.",
                    "Dane kontrahenta motoryzacyjnego i koszty surowców szyfrowane w bazie."
                }),
            new(
                "NFR03",
                "Użyteczność",
                "Interfejs dla operatorów z dużymi przyciskami (min. 100x100 px).",
                new List<string>
                {
                    "Nowy operator raportuje wykonanie zadania po maks. 15 minutach szkolenia."
                }),
            new(
                "NFR04",
                "Dostępność",
                "Dostępność 99,5% w godzinach pracy hali i biura.",
                new List<string>
                {
                    "Maksymalny czas awarii raportowania pracy: 30 minut."
                }),
            new(
                "NFR05",
                "Kompatybilność",
                "Obsługa Chrome i Firefox od wersji 110 oraz import arkuszy Excel.",
                new List<string>
                {
                    "Interfejs działa na przemysłowych tabletach i komputerach biurowych."
                }),
            new(
                "NFR06",
                "Skalowalność",
                "Obsługa historii minimum 5 lat produkcji bez spadku wydajności.",
                new List<string>
                {
                    "Archiwizacja danych co 24 godziny poza godzinami pracy biura."
                })
        };

        return new SpecificationDocument(
            metadata,
            overview,
            modules,
            actors,
            businessObjects,
            businessProcesses,
            functionalRequirements,
            nonFunctionalRequirements);
    }
}
