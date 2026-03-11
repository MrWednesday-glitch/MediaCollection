namespace MediaCollection.API.Models;

public record ErrorDetails(string Type, string Title, int Status, string Detail, string Instance)
{
}
