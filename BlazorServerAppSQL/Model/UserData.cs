using System.ComponentModel.DataAnnotations;

namespace BlazorServerAppSQL.Model;


public class UserData
{
    [Key]
    [Editable(false)]
    public int UserDataId { get; set; }

    [Required]
    [StringLength(255)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public DateTime? EmploymentDate { get; set; }

    public decimal? Salary { get; set; } 

    public int? UserCategory_Id { get; set; }

}
