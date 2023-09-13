namespace FptUni.BpHostpital.Auth.Utils;

public class JwtSettingModels
{
    #region [ Properties ]
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string Secret { get; set; }
    #endregion
}