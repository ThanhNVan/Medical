using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(UserRole))]
[Index(nameof(DepartmentId), nameof(RoleId), nameof(UserId), IsUnique = true)]
public class UserRole : BaseEntity
{
    #region [ Properties - FK]
    [Required]
    [DataType(DataType.Text)]
    public string DepartmentId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(DepartmentId))]
    [InverseProperty("UserRoles")]
    public Department Department { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string RoleId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(RoleId))]
    [InverseProperty("UserRoles")]
    public Role Role { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public string UserId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(RoleId))]
    [InverseProperty("UserRoles")]
    public User User { get; set; }
    #endregion
}
