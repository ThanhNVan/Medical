﻿using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(Role))]
[Index(nameof(Name), IsUnique = true)]
public class Role : BaseEntity
{
    #region [ Properties ]
    public string Name { get; set; }
    #endregion

    #region [ Properties - Virtual]
    [NotMapped]
    [JsonIgnore]
    [InverseProperty("Role")]
    public virtual ICollection<UserRole>? UserRoles { get; set; }
    #endregion
}
