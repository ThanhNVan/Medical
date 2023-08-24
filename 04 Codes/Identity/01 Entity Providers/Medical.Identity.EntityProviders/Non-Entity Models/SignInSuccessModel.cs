using System.Collections.Generic;

namespace Medical.Identity.EntityProviders;

public class SignInSuccessModel
{
    #region [ Properties ]
    public string Email { get; set; }

    public string Fullname { get; set; }

    public IList<string> Role { get; set; }

    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
    #endregion
}
