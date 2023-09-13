namespace FptUni.BpHostpital.Auth.Utils;

public class SignInSuccessModel
{
    #region [ Properties ]
    public string Email { get; set; }

    public string Fullname { get; set; }

    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
    #endregion
}
