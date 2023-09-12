using ShareLibrary.EntityProviders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FptUni.BpHostpital.HR.Utils;

[Table(nameof(UserAddress))]
public class UserAddress : BaseEntity
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Address { get; set; }

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
}
