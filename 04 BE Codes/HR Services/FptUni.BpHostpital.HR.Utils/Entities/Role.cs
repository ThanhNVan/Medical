using Microsoft.EntityFrameworkCore;
using ShareLibrary.EntityProviders;
using System.ComponentModel.DataAnnotations.Schema;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(Role))]
[Index(nameof(Name), IsUnique = true)]
public class Role : BaseEntity
{
    #region [ Properties ]
    public string Name { get; set; }
    #endregion
}
