using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(LeaveRequest))]
public class LeaveRequest : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate{ get; set; }

    [Required]
    public LeaveType LeaveType { get; set; }

    [Required]
    public LeaveState LeaveState { get; set; }
    #endregion

    #region [ Properties - FK ]
    [Required]
    [DataType(DataType.Text)]
    public string UserId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(UserId))]
    [InverseProperty("LeaveRequests")]
    public User User { get; set; }
    #endregion
}
