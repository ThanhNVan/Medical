using System;

namespace FptUni.BpHospital.Common.DTOs;

public class UserSession
{
    #region [ Properties ]
    public string Email { get; set; }

    public string Fullname { get; set; }

    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public int ExpriesIn { get; set; }

    public DateTime ExpiryTimeStamp { get; set; }
    #endregion
}
