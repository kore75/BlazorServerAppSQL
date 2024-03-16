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

            _context.UserDatas.Add(new UserData() { FullName="John Doe", Email= "Doe@gmail.cox", Salary=232, UserCategory_Id=1, EmploymentDate= DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe1", Email = "Doe1@gmail.cox", Salary = 232, UserCategory_Id = 1, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe2", Email = "Doe2@gmail.cox", Salary = 232.1M, UserCategory_Id = 2, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe3", Email = "Doe3@gmail.cox", Salary = 233.1M, UserCategory_Id = 3, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe4", Email = "Doe4@gmail.cox", Salary = 234.2M, UserCategory_Id = 1, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe5", Email = "Doe5@gmail.cox", Salary = 235.3M, UserCategory_Id = 2, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe6", Email = "Doe6@gmail.cox", Salary = 236.4M, UserCategory_Id = 3, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe6", Email = "Doe7@gmail.cox", Salary = 237.5M, UserCategory_Id = 1, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe8", Email = "Doe8@gmail.cox", Salary = 238.6M, UserCategory_Id = 2, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe9", Email = "Doe9@gmail.cox", Salary = 239.1M, UserCategory_Id = 3, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.UserDatas.Add(new UserData() { FullName = "John Doe10", Email = "Doe10@gmail.cox", Salary = 240, UserCategory_Id = 1, EmploymentDate = DateTime.Today.AddDays(-10) });
            _context.SaveChanges();
        }
    }
}
