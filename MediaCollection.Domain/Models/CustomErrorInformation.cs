namespace MediaCollection.Domain;

public record CustomErrorInformation(int StatusCode, string Message, string Owner = "Raven", string AppName = "Media Collection")
{
}
