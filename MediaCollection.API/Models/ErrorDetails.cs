namespace MediaCollection.API;

public record ErrorDetails(string Type, string Title, int Status, string Detail, string Instance)
{
}
