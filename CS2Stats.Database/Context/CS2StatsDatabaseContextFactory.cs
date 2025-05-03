using CS2Stats.Infrastructure.Config;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2Stats.Database.Context;

public class CS2StatsDatabaseContextFactory : IDesignTimeDbContextFactory<CS2StatsDatabaseContext>
{
    public CS2StatsDatabaseContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath($"{Directory.GetCurrentDirectory()}")
            .AddJsonFile($"appsettings.Development.json");

        var configuration = builder.Build();
        AppConfig.Init(configuration);

        return new CS2StatsDatabaseContext();
    }
}
