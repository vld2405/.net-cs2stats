using CS2Stats.Database.Context;
using CS2Stats.Database.Entities;

namespace CS2Stats.Database.Repositories;

public class PlayersRepository : BaseRepository<Player>
{
    public PlayersRepository(CS2StatsDatabaseContext cs2StatsDatabaseContext) : base(cs2StatsDatabaseContext)
    {
        this.cs2StatsDatabaseContext = cs2StatsDatabaseContext;
        Console.WriteLine("PlayersRepository initialized");
    }

    public async Task AddAsync(Player entity)
    {
        cs2StatsDatabaseContext.Players.Add(entity);
        await SaveChangesAsync();
    }
}
