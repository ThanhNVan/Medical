using System.Threading;
using System;
using System.Collections.Generic;
using FptUni.BpHostpital.HR.Utils;

namespace FptUni.BpHostpital.HR.WebApiHost;

public class DataFactory
{
    #region [ Singleton ]
    private static readonly Lazy<DataFactory> _current = new Lazy<DataFactory>(() => new DataFactory(), LazyThreadSafetyMode.PublicationOnly);
    public static DataFactory Current
    {
        get { return _current.Value; }
    }
    #endregion

    #region [ CTor ]
    public DataFactory()
    {
        ContactPersons = new();
        Departments = new();
        Occupations = new();
        Profiles = new();
        Roles = new();
        Users = new();
        UserRoles = new();

        this.AddData();
    }
    #endregion

    #region [ Property ]
    public List<ContactPerson> ContactPersons { get; private set; }
    public List<Department> Departments { get; private set; }
    public List<Occupation> Occupations { get; private set; }
    public List<Profile> Profiles { get; private set; }
    public List<Role> Roles { get; private set; }
    public List<User> Users { get; private set; }
    public List<UserRole> UserRoles { get; private set; }
    #endregion

    #region [ Methods - Data ]
    public void ClearData()
    {
        ContactPersons.Clear();
        Departments.Clear();
        Occupations.Clear();
        Profiles.Clear();
        Roles.Clear();
        Users.Clear();
        UserRoles.Clear();
    }

    public void AddData()
    {
        this.AddData_Roles();
        this.AddData_Departments();
        this.AddData_Occupations();
    }
    #endregion

    #region [ Methods - Populate Data ]
    public void AddData_ContactPersons()
    {

    }
    
    public void AddData_Roles()
    {
        var dateTime = DateTime.UtcNow;
        var  role_0 = new Role() 
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Director"
        };
        
        var  role_1 = new Role() 
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Team Leader"
        };
        
        var  role_2 = new Role() 
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Member"
        };
        
        var  role_3 = new Role() 
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Dean"
        };
        
        var  role_4 = new Role() 
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Intern"
        };
        
        var  role_5 = new Role() 
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Intern"
        };
    }   

    public void AddData_Departments()
    {

    }
    
    public void AddData_Occupations()
    {

    }
    #endregion
}
