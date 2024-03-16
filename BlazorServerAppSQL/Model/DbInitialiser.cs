using BlazorSQLData.Model;

namespace BlazorServerAppSQL.Model;

public class DbInitialiser
{
    private readonly BookingDataContext _context;

    public DbInitialiser(BookingDataContext context)
    {
        _context = context;
    }

    public void Run()
    {
        _context.Database.EnsureCreated();
    }
}
