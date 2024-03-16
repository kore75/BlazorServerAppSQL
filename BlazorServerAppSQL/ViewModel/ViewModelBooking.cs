using BlazorServerAppSQL.Model;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Linq;
namespace BlazorServerAppSQL.ViewModel;

public class ViewModelBooking
{
    private BookingDataContext _context;
    public ViewModelBooking(BookingDataContext context)
    {
        _context = context;
    }

    public async Task<UserDataDto?> GetUserDataDtosById(int userdataId)
    {
        return await GetUserDataDtos().FirstOrDefaultAsync(x=>x.UserDataId == userdataId);
    }

        public IQueryable<UserDataDto> GetUserDataDtos()
    {      
        var userDtos=(from ud in _context.UserDatas.AsNoTracking() join
                     cd in _context.UserCategories.AsNoTracking().DefaultIfEmpty() on
                     ud.UserCategory_Id equals cd.UserCategoryId
                     select new UserDataDto 
                     { 
                         Email=ud.Email, 
                         EmploymentDate=ud.EmploymentDate, 
                         FullName=ud.FullName, 
                         Salary=ud.Salary, 
                         UserDataId=ud.UserDataId,
                         UserCategory=cd.Name
                     });

        return userDtos;

    }
}
