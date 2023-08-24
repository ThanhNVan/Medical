using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Medical.Identity.EntityProviders;

[Table(nameof(User))]
[Index(nameof(Email), IsUnique = true)]
public class User : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string PasswordHash { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Firstname { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Lastname { get; set; }

    [NotMapped]
    [JsonIgnore]
    public string Fullname => Firstname + " " + Lastname;
    #endregion

    #region [ Properties - Virtual ]
    [JsonIgnore]
    [NotMapped]
    [InverseProperty("User")]
    public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }

    [JsonIgnore]
    [NotMapped]
    [InverseProperty("User")]
    public virtual ICollection<UserRole>? UserRoles { get; set; }
    #endregion
}
