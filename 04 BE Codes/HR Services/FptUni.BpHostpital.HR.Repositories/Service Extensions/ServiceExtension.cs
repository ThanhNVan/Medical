﻿using Microsoft.Extensions.DependencyInjection;
using ShareLibrary.EntityProviders;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public static class ServiceExtension
{
    public static void AddHrRepositories(this IServiceCollection services)
    {
        services.AddTransient<IContactPersonRepository, ContactPersonRepository>();
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        services.AddTransient<IProfileRepository, ProfileRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserRoleRepository, UserRoleRepository>();
        services.AddTransient<IEncriptionProvider, EncriptionProvider>();
        services.AddTransient<IOccupationRepository, OccupationRepository>();
        services.AddTransient<IAttendanceRepository, AttendanceRepository>();
        services.AddTransient<ILeaveRequestRepository, LeaveRequestRepository>();


        services.AddTransient<RepositoryContext>();
    }
}
