using System.ComponentModel.DataAnnotations;

namespace FptUni.BpHostpital.Auth.Utils;

public class SignUpModel
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Firstname { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Lastname { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    #endregion
}
