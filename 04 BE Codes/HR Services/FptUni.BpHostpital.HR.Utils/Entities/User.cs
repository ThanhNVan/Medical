using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(User))]
[Index(nameof(EmailAddress), IsUnique = true)]
public class User : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Firstname { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Lastname { get; set; }

    [NotMapped]
    [JsonIgnore]
    public string Fullname => Firstname + " " + Lastname; 

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber1 { get; set; }
    
    
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber2 { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set;}
    
    [Required]
    [DataType(DataType.Text)]
    public string OccupationId { get; set;}
    #endregion

    #region [ Properties - Virtual]
    [JsonIgnore]
    [NotMapped]
    [InverseProperty("User")]
    public virtual ICollection<ContactPerson>? ContactPersons { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    [InverseProperty("User")]
    public virtual ICollection<UserRole>? UserRoles { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    [InverseProperty("User")]
    public virtual ICollection<LeaveRequest>? LeaveRequests { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    [InverseProperty("User")]
    public virtual ICollection<Attendance>? Attendances { get; set; }

    [JsonIgnore]
    [NotMapped]
    [InverseProperty("User")]
    public virtual Profile? Profile { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(OccupationId))]
    [InverseProperty("Users")]
    public Occupation? Occupation { get; set; }
    #endregion
}
