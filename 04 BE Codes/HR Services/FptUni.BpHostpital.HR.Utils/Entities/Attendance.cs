using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using ShareLibrary.EntityProviders;
using System.Text.Json.Serialization;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(Attendance))]
public class Attendance : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateTimeIn { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateTimeOut { get; set; }
    #endregion

    #region [ Properties - FK ]
    [Required]
    [DataType(DataType.Text)]
    public string UserId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(UserId))]
    [InverseProperty("Attendances")]
    public User User { get; set; }
    #endregion
}
