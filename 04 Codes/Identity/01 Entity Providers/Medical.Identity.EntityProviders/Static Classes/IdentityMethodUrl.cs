namespace Medical.Identity.EntityProviders;

public static class IdentityMethodUrl
{
    #region [ Properties ]
    public static string SignIn = "/SignIn/";

    public static string GetSingleByEmail = "/GetSingleByEmail/";

    public static string GetListByUserId = "/GetListByUserId/";

    public static string RenewToken = "/RenewToken/";
    #endregion
}
