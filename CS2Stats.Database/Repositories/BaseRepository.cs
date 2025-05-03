using CS2Stats.Database.Context;
using CS2Stats.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Database.Repositories;

public class BaseRepository<T> where T : BaseEntity
{
    protected CS2StatsDatabaseContext cs2StatsDatabaseContext { get; set; }
    public BaseRepository(CS2StatsDatabaseContext databaseContext)
    {
        this.cs2StatsDatabaseContext = databaseContext;
        DbSet = databaseContext.Set<T>();
    }

    private DbSet<T> DbSet { get; }

    public Task<List<T>> GetAllAsync(bool includeDeletedEntities = false)
    {
        return GetRecords(includeDeletedEntities).ToListAsync();
    }

    public Task<T?> GetFirstOrDefaultAsync(int primaryKey, bool includeDeletedEntities = false)
    {
        var records = GetRecords(includeDeletedEntities);

        return records.FirstOrDefaultAsync(record => record.Id == primaryKey);
    }

    public void Insert(params T[] records)
    {
        DbSet.AddRange(records);
    }

    public void Update(params T[] records)
    {
        foreach (var baseEntity in records)
        {
            baseEntity.ModifiedAt = DateTime.UtcNow;
        }

        DbSet.UpdateRange(records);
    }

    public void SoftDelete(params T[] records)
    {
        foreach (var baseEntity in records)
        {
            baseEntity.DeletedAt = DateTime.UtcNow;
        }

        Update(records);
    }

    public Task SaveChangesAsync()
    {
        return cs2StatsDatabaseContext.SaveChangesAsync();
    }

    protected IQueryable<T> GetRecords(bool includeDeletedEntities = false)
    {
        var result = DbSet.AsQueryable();

        if (includeDeletedEntities is false)
        {
            result = result.Where(r => r.DeletedAt == null);
        }

        return result;
    }
}
