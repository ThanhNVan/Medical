namespace ShareLibrary.EntityProviders;

public static class BaseMethodUrl
{
    #region [ Properties ]
    public static string Add = "/Add/";

    public static string GetSingleById = "/GetSingleById/";

    public static string Update = "/Update/";

    public static string SoftDelete = "/SoftDelete/";

    public static string Recover = "/Recover/";

    public static string Destroy = "/Destroy/";

    public static string GetListAll = "/GetListAll/";

    public static string GetListIsDeleted = "/GetListIsDeleted/";

    public static string GetListIsNotDeleted = "/GetListIsNotDeleted/";

    public static string CountAll = "/CountAll/";

    public static string CountIsDeleted = "/CountIsDeleted/";

    public static string CountIsNotDeleted = "/CountIsNotDeleted/";

    public static string SignIn = "/SignIn/";

    public static string SignUp = "/SignUp/";

    public static string SignOut = "/SignOut/";

    public static string RenewToken = "/RenewToken/";

    public static string GetSingleByEmail = "/GetSingleByEmail/";

    public static string GetListByUserId = "/GetListByUserId/";
    #endregion
}
