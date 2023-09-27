using System.ComponentModel.DataAnnotations;

namespace FptUni.BpHospital.Common.DTOs;

public class SignInModel
{
    #region [ Properties ]
    [Required]
    [DataType(DataType.Text)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    #endregion
}
