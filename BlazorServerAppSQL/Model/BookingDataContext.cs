using BlazorServerAppSQL.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BlazorServerAppSQL.Model;

public class BookingDataContext: DbContext
{
    public string? DbPath { get; } = null;

    public DbSet<UserData> UserDatas { get; set; }

    public DbSet<UserCategory> UserCategories { get; set; }

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
        modelBuilder.Entity<UserData>(build =>
        {
            build.Property(e => e.UserDataId).ValueGeneratedOnAdd();
            build.HasOne<UserCategory>().WithMany().HasForeignKey(x => x.UserCategory_Id);
        });

        modelBuilder.Entity<UserCategory>(build =>
        {
            build.Property(e => e.UserCategoryId).ValueGeneratedOnAdd();
        });
        

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
