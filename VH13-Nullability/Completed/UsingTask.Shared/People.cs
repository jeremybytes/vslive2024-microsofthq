namespace UsingTask.Shared;

public static class People
{
    public static List<Person> GetPeople()
    {
        List<Person> p =
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
        ];
        return p;
    }
}
