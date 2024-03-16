

namespace BlazorServerAppSQL.ViewModel;
public class UserDataDto
{
    public int UserDataId { get; set; }
    public string FullName { get; set; } = string.Empty;    
    public string Email { get; set; } = string.Empty;
    public DateTime? EmploymentDate { get; set; }
    public decimal? Salary { get; set; } 
    public string? UserCategory { get; set; }

}
