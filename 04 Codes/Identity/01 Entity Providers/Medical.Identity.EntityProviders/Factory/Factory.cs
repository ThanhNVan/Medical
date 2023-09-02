namespace Medical.Identity.EntityProviders;

public static class Factory
{
    public static User CreateUser(string email,
                                    string password,
                                    string firstname,
                                    string lastname)
    {
        var result = new User();
        result.Email = email;
        result.PasswordHash = password;
        result.Firstname = firstname;
        result.Lastname = lastname;

        return result;
    }

    public static UserRole CreateHRManager(string userId)
    {
        var result = new UserRole();

        result.UserId = userId;
        result.RoleId = "db266e1f-71b9-4b55-8e6c-dcd9e3033651";
        result.DepartmentId = "fc47cfe0-42ef-4e6c-bcdd-3ee73322a4ae";

        return result;
    }
    
    public static UserRole CreateSalesManager(string userId)
    {
        var result = new UserRole();

        result.UserId = userId;
        result.RoleId = "db266e1f-71b9-4b55-8e6c-dcd9e3033651";
        result.DepartmentId = "956a9aaf-cfd0-481b-a006-81569c33f303";

        return result;
    }
}
