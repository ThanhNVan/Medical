using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Medical.Identity.EntityProviders;

[Table(nameof(Department))]
[Index(nameof(Name), IsUnique = true)]
public class Department : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Name { get; set; }
    #endregion

    #region [ Properties - Virtual ]
    [JsonIgnore]
    [NotMapped]
    [InverseProperty("Department")]
    public virtual ICollection<UserRole>? UserRoles { get; set; }
    #endregion
}
