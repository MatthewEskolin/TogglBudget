using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TogglTimeWeb.Shared;

namespace TogglTimeWeb.Server.Data;

public class TogglTimeContext:DbContext
{
    public DbSet<TimeLimit> TimeLimits =>  Set<TimeLimit>();
    public string DbPath { get; set; }


    public TogglTimeContext()
    {           
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "sqlite.db");

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


}