using System.ComponentModel.DataAnnotations;

namespace BlazorServerAppSQL.Model;

public class UserCategory
{
    [Key]
    [Editable(false)]
    public int UserCategoryId { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
}
