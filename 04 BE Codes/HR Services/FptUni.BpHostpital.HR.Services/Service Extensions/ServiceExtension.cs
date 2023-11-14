using Microsoft.Extensions.DependencyInjection;

namespace FptUni.BpHostpital.HR.Services;

public static class ServiceExtension
{
    public static void AddHrServices(this IServiceCollection services)
    {
        services.AddTransient<IContactPersonService, ContactPersonService>();
        services.AddTransient<IDepartmentService, DepartmentService>();
        services.AddTransient<IProfileService, ProfileService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IUserRoleService, UserRoleService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IOccupationService, OccupationService>();
        services.AddTransient<ILeaveRequestService, LeaveRequestService>();
        services.AddTransient<IAttendanceService, AttendanceService>();

        services.AddTransient<ServiceContext>();
    }
}
