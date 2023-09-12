using ShareLibrary.EntityProviders;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FptUni.BpHostpital.Auth.Utils;

[Table(nameof(RefreshToken))]
public class RefreshToken : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Token { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string JwtId { get; set; }

    public bool IsUsed { get; set; }

    public bool IsRevoked { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime IssuedAt { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime ExpiredAt { get; set; }
    #endregion

    #region [ Properties - FK ]
    public string UserId { get; set; }

    [Required]
    [JsonIgnore]
    [ForeignKey(nameof(UserId))]
    [InverseProperty("RefreshTokens")]
    public ApplicationUser ApplicationUser { get; set; }
    #endregion
}
