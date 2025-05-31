namespace CatchUpPlatform.API.News.Domain.Model.Aggregates;

public class FavoriteSource
{
    public int Id { get; }
    public string NewsApiKey { get; private set; }
    public string SourceId { get; private set; }
}