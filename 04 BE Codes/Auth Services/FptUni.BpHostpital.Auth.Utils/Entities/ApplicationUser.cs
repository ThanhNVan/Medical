using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FptUni.BpHostpital.Auth.Utils;

[Table(nameof(ApplicationUser))]
[Index(nameof(Email), nameof(UserName), IsUnique = true)]
public class ApplicationUser : IdentityUser
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Firstname { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Lastname { get; set; }

    [NotMapped]
    public string Fullname => this.Firstname + " " + this.Lastname;
    #endregion

    #region [ Properties ]
    [JsonIgnore]
    [NotMapped]
    [InverseProperty("ApplicationUser")]
    public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
    #endregion
}
