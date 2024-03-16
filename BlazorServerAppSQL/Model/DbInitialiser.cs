using BlazorServerAppSQL.Model;

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
        if(_context.Database.EnsureCreated())
        {
            _context.UserCategories.Add(new UserCategory() { Name = "Developer" });
            _context.UserCategories.Add(new UserCategory() { Name = "Guest" });
            _context.UserCategories.Add(new UserCategory() { Name = "Manager" });
            _context.SaveChanges();
        }
    }
}
