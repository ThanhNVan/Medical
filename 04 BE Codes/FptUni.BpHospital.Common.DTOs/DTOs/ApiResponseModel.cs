﻿namespace FptUni.BpHospital.Common.DTOs;

public class RenewTokenResponseModel
{
    #region [ Properties ]
    public bool Success { get; set; }

    public string Message { get; set; }

    public TokenModel Data { get; set; }
    #endregion
}
