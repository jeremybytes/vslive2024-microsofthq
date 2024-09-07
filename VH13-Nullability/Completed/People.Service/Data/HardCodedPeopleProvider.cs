namespace People.Service;
public class HardCodedPeopleProvider : IPeopleProvider
{
    public List<Person> GetPeople() =>
        [
            new(1, "John", "Koenig", new DateTime(1975, 10, 17), 6, ""),
            new(2, "Dylan", "Hunt", new DateTime(2000, 10, 2), 8, ""),
            new(3, "Leela", "Turanga", new DateTime(1999, 3, 28), 8, "{1} {0}"),
            new(4, "John", "Crichton", new DateTime(1999, 3, 19), 7, ""),
            new(5, "Dave", "Lister", new DateTime(1988, 2, 15), 9, ""),
            new(6, "Laura", "Roslin", new DateTime(2003, 12, 8), 6, ""),
            new(7, "John", "Sheridan", new DateTime(1994, 1, 26), 6, ""),
            new(8, "Dante", "Montana", new DateTime(2000, 11, 1), 5, ""),
            new(9, "Isaac", "Gampu", new DateTime(1977, 9, 10), 4, ""),
            new(10, "Camina", "Drummer", new DateTime(2015, 11, 23), 7, ""),
            new(11, "John", "Boon", new DateTime(1993, 01, 06), 5, ""),
            new(12, "Kerr", "Avon", new DateTime(1978, 01, 02), 8, ""),
            new(13, "Ed", "Mercer", new DateTime(2017, 09, 10), 8, ""),
            new(14, "Devon", "", new DateTime(1973, 09, 23), 4, "{0}"),
        ];

    public Person? GetPerson(int id) =>
        GetPeople().FirstOrDefault(p => p.Id == id);
}
