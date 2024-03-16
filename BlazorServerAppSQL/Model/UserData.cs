using System.ComponentModel.DataAnnotations;

namespace BlazorSQLData.Model;


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
    public string Email { get; set; } = string.Empty;
}
