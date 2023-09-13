using ShareLibrary.EntityProviders;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(Profile))]
public class Profile : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateHired { get; set; }
    #endregion
}
