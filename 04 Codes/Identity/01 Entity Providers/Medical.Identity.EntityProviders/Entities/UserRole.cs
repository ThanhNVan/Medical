using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Medical.Identity.EntityProviders;

[Table(nameof(UserRole))]
[Index(nameof(RoleId), nameof(UserId), IsUnique = true)]
public class UserRole : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string RoleId { get; set; }

    [Required]
    [JsonIgnore]
    [ForeignKey(nameof(RoleId))]
    [InverseProperty("UserRoles")]
    public Role Role { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string UserId { get; set; }

    [Required]
    [JsonIgnore]
    [ForeignKey(nameof(UserId))]
    [InverseProperty("UserRoles")]
    public User User { get; set; }
    #endregion
}
