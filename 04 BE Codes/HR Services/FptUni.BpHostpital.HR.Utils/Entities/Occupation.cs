using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(Occupation))]
public class Occupation : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Name { get; set; }
    #endregion

    #region [ Properties - Virtual ]
    [JsonIgnore]
    [NotMapped]
    [InverseProperty("Occupation")]
    public virtual ICollection<User>? Users { get; set; }
    #endregion
}
