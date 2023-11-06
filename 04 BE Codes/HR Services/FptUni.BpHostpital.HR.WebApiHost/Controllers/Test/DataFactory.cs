using System.Threading;
using System;
using System.Collections.Generic;
using FptUni.BpHostpital.HR.Utils;
using System.Net.Mail;

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
        this.AddData_User();
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
            Name = "Staff"
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
        
        this.Roles.Add(role_0);
        this.Roles.Add(role_1);
        this.Roles.Add(role_2);
        this.Roles.Add(role_3);
        this.Roles.Add(role_4);
    }   

    public void AddData_Departments()
    {
        //Surgery: ngoại khoa
        //Internal medicine: nội khoa
        //Neurosurgery: ngoại thần kinh
        //Plastic surgery: phẫu thuật tạo hình
        //Orthopedic surgery: ngoại chỉnh hình.
        //Thoracic surgery: ngoại lồng ngực
        //Nuclear medicine: y học hạt nhân
        //Preventative / preventive medicine: y học dự phòng
        //Allergy: dị ứng học
        //An(a)esthesiology: chuyên khoa gây mê
        //Andrology: nam khoa
        //Cardiology: khoa tim
        //Dermatology: chuyên khoa da liễu
        //Dietetics(and nutrition): khoa dinh dưỡng
        //Endocrinology: khoa nội tiết
        //Epidemiology: khoa dịch tễ học
        //Gastroenterology: khoa tiêu hóa
        //Geriatrics: lão khoa.
        //Gyn(a)ecology: phụ khoa
        //H(a)ematology: khoa huyết học
        //Immunology: miễn dịch học
        //Nephrology: thận học
        //Neurology: khoa thần kinh
        //Odontology: khoa răng
        //Oncology: ung thư học
        //Ophthalmology: khoa mắt
        //Orthop(a)edics: khoa chỉnh hình
        //Traumatology: khoa chấn thương
        //Urology: niệu khoa
        //Outpatient department: khoa bệnh nhân ngoại trú
        //Inpatient department: khoa bệnh nhân ngoại trú

        var dateTime = DateTime.UtcNow;
        var department_0 = new Department()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Human Resource"
        };
        
        var department_1 = new Department()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Ophthalmology" // khoa mắt
        };
        
        var department_2 = new Department()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Emergency"
        };


        var department_3 = new Department()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Nursing"
        };

        var department_4 = new Department()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Finance"
        };
        
        var department_5 = new Department()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Dermatology"
        };

        var department_6 = new Department()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Dietetics"
        };

        var department_7 = new Department()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Gastroenterology"
        };
        
        var department_8 = new Department()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Gastroenterology"
        };
        this.Departments.Add(department_0);
        this.Departments.Add(department_1);
        this.Departments.Add(department_2);
        this.Departments.Add(department_3);
        this.Departments.Add(department_4);
        this.Departments.Add(department_5);
        this.Departments.Add(department_6);
        this.Departments.Add(department_7);
        this.Departments.Add(department_8);
    }

    public void AddData_Occupations()
    {
        var dateTime = DateTime.UtcNow;

        var occupation_0 = new Occupation()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Doctor"
        };
        
        var occupation_1 = new Occupation()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Staff"
        };
        
        var occupation_2 = new Occupation()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Nurse"
        };
        
        var occupation_3 = new Occupation()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Admin"
        };
        
        var occupation_4 = new Occupation()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Intern"
        };
        
        var occupation_5 = new Occupation()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Accountant"
        };
        
        var occupation_6 = new Occupation()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "IT"
        };

        this.Occupations.Add(occupation_0);
        this.Occupations.Add(occupation_1);
        this.Occupations.Add(occupation_2);
        this.Occupations.Add(occupation_3);
        this.Occupations.Add(occupation_4);
        this.Occupations.Add(occupation_5);
        this.Occupations.Add(occupation_6);
    }

    private void AddData_User()
    {
        var dateTime = DateTime.UtcNow;
        var user_0 = new User()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "First_First",
            Lastname = "First_Last",
            PhoneNumber1 = "1111110000",
            PhoneNumber2 = "1222220000",
            EmailAddress = "first.first@gmail.com",
            OccupationId = this.Occupations[0].Id,
        };
        
        var user_1 = new User()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Second_First",
            Lastname = "Second_Last",
            PhoneNumber1 = "1111110000",
            PhoneNumber2 = "1222220000",
            EmailAddress = "second.second@gmail.com",
            OccupationId = this.Occupations[1].Id,
        };
    }
    #endregion
}
