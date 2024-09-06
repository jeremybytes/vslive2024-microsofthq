namespace UsingTask.Shared;

public record Person(int Id, string GivenName, string FamilyName,
    DateTime StartDate, int Rating, string FormatString = "")
{
    public override string ToString() =>
        string.IsNullOrEmpty(FormatString)
        ? $"{GivenName} {FamilyName}"
        : string.Format(FormatString, GivenName, FamilyName);
}
