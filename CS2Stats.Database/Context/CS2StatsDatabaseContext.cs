using CS2Stats.Database.Entities;
using CS2Stats.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Database.Context;

public class CS2StatsDatabaseContext : DbContext
{
    public CS2StatsDatabaseContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConfig.ConnectionStrings?.CS2StatsDatabase);//.LogTo(Console.WriteLine);
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Player> Teams { get; set; }

}
