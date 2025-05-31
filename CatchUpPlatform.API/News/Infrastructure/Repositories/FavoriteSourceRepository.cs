using CatchUpPlatform.API.News.Domain.Model.Aggregates;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatform.API.News.Infrastructure.Repositories;

public class FavoriteSourceRepository(AppDbContext context) : BaseRepository<FavoriteSource>(context)
{
    public async Task<FavoriteSource?> FindByNewsApiKeyAndSourceIdAsync(string newsApiKey, string sourceId)
    {
        return await Context.Set<FavoriteSource>()
            .FirstOrDefaultAsync(f => f.NewsApiKey == newsApiKey && f.SourceId == sourceId);
    }
    
}