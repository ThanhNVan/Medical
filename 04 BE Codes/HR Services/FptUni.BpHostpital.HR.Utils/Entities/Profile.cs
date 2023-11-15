using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(Profile))]
[Index(nameof(UserId), IsUnique = true)]
public class Profile : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateHired { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Address { get; set; }


    [Required]
    [DataType(DataType.Text)]
    public string Ward { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string City { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string State { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Country { get; set; }

    [Required]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; }
    #endregion

    #region [ Properties - FK ]
    [Required]
    [DataType(DataType.Text)]
    public string UserId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(UserId))]
    [InverseProperty("Profile")]
    public User User { get; set; }
    #endregion
}
