namespace MediaCollection.Domain;

public record CustomErrorInformation(string Message, string Owner = "Raven", string AppName = "Media Collection")
{
}
