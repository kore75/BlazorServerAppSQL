using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BlazorSQLData.Model;

public class BookingDataContext: DbContext
{
    public string? DbPath { get; } = null;

    public DbSet<UserData> UserDatas { get; set; }

    public BookingDataContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "userdata.db");
    }

    public BookingDataContext(DbContextOptions<BookingDataContext> options):base(options) 
    {        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserData>()
            .Property(e => e.UserDataId)
            .ValueGeneratedOnAdd();
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if(!options.IsConfigured)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }        
}
