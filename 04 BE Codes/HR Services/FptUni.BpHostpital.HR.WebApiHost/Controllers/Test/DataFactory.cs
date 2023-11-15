using System.Threading;
using System;
using System.Collections.Generic;
using FptUni.BpHostpital.HR.Utils;
using FptUni.BpHospital.Common;

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
        LeaveRequests = new();
        Attendances = new();

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
    public List<LeaveRequest> LeaveRequests { get; private set; }
    public List<Attendance> Attendances { get; private set; }
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
        LeaveRequests.Clear();
        Attendances.Clear();
    }

    public void AddData()
    {
        this.AddData_Roles();
        this.AddData_Departments();
        this.AddData_Occupations();
        this.AddData_User();
        this.AddData_ContactPersons();
        this.AddData_UserRole();
        this.AddData_Profile();
        this.AddData_Attendance();
        this.AddData_LeaveRequest();
    }
    #endregion

    #region [ Methods - Populate Data ]
    public void AddData_ContactPersons()
    {
        var dateTime = DateTime.UtcNow;
        var contactPerson_0 = new ContactPerson()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Adam",
            Lastname = "First_L",
            PhoneNumber1 = "123400000",
            RelationshipWithUser = RelationshipWithUser.Father,
            EmailAddress = "Adam.First_L@gmail.com",
            Address = "113 Nguyen Trai",
            Ward = "1",
            City = "District 10",
            State = "Ho Chi Minh City",
            Country = "Vietnam",
            PostalCode = "700000",
            UserId = this.Users[0].Id
        };

        var contactPerson_1 = new ContactPerson()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Eva",
            Lastname = "Second_L",
            PhoneNumber1 = "123400001",
            RelationshipWithUser = RelationshipWithUser.Mother,
            EmailAddress = "Eva.Second_L@gmail.com",
            Address = "113 Xa Lo Hanoi",
            Ward = "Tay Loc",
            City = "District 9",
            State = "Ho Chi Minh City",
            Country = "Vietnam",
            PostalCode = "700000",
            UserId = this.Users[1].Id
        };

        var contactPerson_2 = new ContactPerson()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Adam",
            Lastname = "Third_L",
            PhoneNumber1 = "123400002",
            RelationshipWithUser = RelationshipWithUser.Grandfather,
            EmailAddress = "Adam.Third_L@gmail.com",
            Address = "666 Tran Duy Hung",
            Ward = "Nam Loc",
            City = "District 8",
            State = "Ho Chi Minh City",
            Country = "Vietnam",
            PostalCode = "700000",
            UserId = this.Users[2].Id
        };

        var contactPerson_3 = new ContactPerson()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Eva",
            Lastname = "Fourth_L",
            PhoneNumber1 = "123400003",
            RelationshipWithUser = RelationshipWithUser.Grandmother,
            EmailAddress = "Eva.Fourth_L@gmail.com",
            Address = "222 Dien Hong",
            Ward = "Bac Loc",
            City = "District 2",
            State = "Ho Chi Minh City",
            Country = "Vietnam",
            PostalCode = "700000",
            UserId = this.Users[3].Id
        };

        var contactPerson_4 = new ContactPerson()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Adam",
            Lastname = "Fifth_L",
            PhoneNumber1 = "123400004",
            RelationshipWithUser = RelationshipWithUser.Brother,
            EmailAddress = "Adam.Fifth_L@gmail.com",
            Address = "222 Le Van Viet",
            Ward = "Dong Loc",
            City = "District 1",
            State = "Ho Chi Minh City",
            Country = "Vietnam",
            PostalCode = "700000",
            UserId = this.Users[4].Id
        };

        var contactPerson_5 = new ContactPerson()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Adam",
            Lastname = "Sixth_L",
            PhoneNumber1 = "123400004",
            RelationshipWithUser = RelationshipWithUser.Brother,
            EmailAddress = "Adam.Sixth_L@gmail.com",
            Address = "222 Le Van Viet",
            Ward = "Dong Ba",
            City = "District 1",
            State = "Ho Chi Minh City",
            Country = "Vietnam",
            PostalCode = "700000",
            UserId = this.Users[5].Id
        };
        
        var contactPerson_6 = new ContactPerson()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Adam",
            Lastname = "Seventh_L",
            PhoneNumber1 = "123400004",
            RelationshipWithUser = RelationshipWithUser.Brother,
            EmailAddress = "Adam.Seventh_L@gmail.com",
            Address = "222 Le Van Viet",
            Ward = "4",
            City = "District 1",
            State = "Ho Chi Minh City",
            Country = "Vietnam",
            PostalCode = "700000",
            UserId = this.Users[6].Id
        };

        this.ContactPersons.Add(contactPerson_0);
        this.ContactPersons.Add(contactPerson_1);
        this.ContactPersons.Add(contactPerson_2);
        this.ContactPersons.Add(contactPerson_3);
        this.ContactPersons.Add(contactPerson_4);
        this.ContactPersons.Add(contactPerson_5);
        this.ContactPersons.Add(contactPerson_6);
    }

    public void AddData_Roles()
    {
        var dateTime = DateTime.UtcNow;
        var role_0 = new Role()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Director"
        };

        var role_1 = new Role()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Staff"
        };

        var role_2 = new Role()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Member"
        };

        var role_3 = new Role()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Name = "Dean"
        };

        var role_4 = new Role()
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
            Name = "Outpatient"
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
            Firstname = "First_F",
            Lastname = "First_L",
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
            Firstname = "Second_F",
            Lastname = "Second_L",
            PhoneNumber1 = "1111110001",
            PhoneNumber2 = "1222220001",
            EmailAddress = "second.second@gmail.com",
            OccupationId = this.Occupations[1].Id,
        };

        var user_2 = new User()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Third_F",
            Lastname = "Third_L",
            PhoneNumber1 = "1111110002",
            PhoneNumber2 = "1222220002",
            EmailAddress = "Third.Third@gmail.com",
            OccupationId = this.Occupations[2].Id,
        };

        var user_3 = new User()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Fourth_F",
            Lastname = "Fourth_L",
            PhoneNumber1 = "1111110004",
            PhoneNumber2 = "1222220004",
            EmailAddress = "Fourth.Fourth@gmail.com",
            OccupationId = this.Occupations[3].Id,
        };

        var user_4 = new User()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Fifth_F",
            Lastname = "Fifth_L",
            PhoneNumber1 = "1111110005",
            PhoneNumber2 = "1222220005",
            EmailAddress = "Fifth.Fifth@gmail.com",
            OccupationId = this.Occupations[4].Id,
        };

        var user_5 = new User()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Sixth_F",
            Lastname = "Sixth_L",
            PhoneNumber1 = "1111110006",
            PhoneNumber2 = "1222220006",
            EmailAddress = "Sixth.Sixth@gmail.com",
            OccupationId = this.Occupations[5].Id,
        };

        var user_6 = new User()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            Firstname = "Seventh_F",
            Lastname = "Seventh_L",
            PhoneNumber1 = "1111110007",
            PhoneNumber2 = "1222220007",
            EmailAddress = "Seventh.Seventh@gmail.com",
            OccupationId = this.Occupations[6].Id,
        };

        this.Users.Add(user_0);
        this.Users.Add(user_1);
        this.Users.Add(user_2);
        this.Users.Add(user_3);
        this.Users.Add(user_4);
        this.Users.Add(user_5);
        this.Users.Add(user_6);
    }

    private void AddData_UserRole()
    {
        var dateTime = DateTime.UtcNow;
        var userRole_0 = new UserRole()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            RoleId = this.Roles[0].Id,
            UserId = this.Users[0].Id,
            DepartmentId = this.Departments[0].Id,
        };
        
        var userRole_1 = new UserRole()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            RoleId = this.Roles[1].Id,
            UserId = this.Users[1].Id,
            DepartmentId = this.Departments[0].Id,
        };
        
        var userRole_2 = new UserRole()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            RoleId = this.Roles[2].Id,
            UserId = this.Users[2].Id,
            DepartmentId = this.Departments[0].Id,
        };
        
        var userRole_3 = new UserRole()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            RoleId = this.Roles[4].Id,
            UserId = this.Users[3].Id,
            DepartmentId = this.Departments[0].Id,
        };
        
        var userRole_4 = new UserRole()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            RoleId = this.Roles[4].Id,
            UserId = this.Users[4].Id,
            DepartmentId = this.Departments[0].Id,
        };

        var userRole_5 = new UserRole()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            RoleId = this.Roles[0].Id,
            UserId = this.Users[5].Id,
            DepartmentId = this.Departments[1].Id,
        };
        
        var userRole_6 = new UserRole()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            RoleId = this.Roles[2].Id,
            UserId = this.Users[6].Id,
            DepartmentId = this.Departments[1].Id,
        };

        this.UserRoles.Add(userRole_0);
        this.UserRoles.Add(userRole_1);
        this.UserRoles.Add(userRole_2);
        this.UserRoles.Add(userRole_3);
        this.UserRoles.Add(userRole_4);
        this.UserRoles.Add(userRole_5);
        this.UserRoles.Add(userRole_6);
    }

    private void AddData_Profile()
    {
        var dateTime = DateTime.UtcNow;
        var profile_0 = new Profile()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[0].Id,
            DateHired = dateTime,
            Address = "113 Tran Phu",
            Ward = "An Hoa",
            City = "District 10",
            State = "Ho Chi Minh city",
            PostalCode = "715000",
            Country = "Vietnam"
        };
        
        var profile_1 = new Profile()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[1].Id,
            DateHired = dateTime,
            Address = "911 Nguyen Trai",
            Ward = "An Hoa",
            City = "Hue City",
            State = "Thua Thien Hue",
            PostalCode = "715000",
            Country = "Vietnam"
        };
        
        var profile_2 = new Profile()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[2].Id,
            DateHired = dateTime,
            Address = "911 Nguyen Trai",
            Ward = "An Hoa",
            City = "Hang Ma",
            State = "Hanoi City",
            PostalCode = "715000",
            Country = "Vietnam"
        };
        
        var profile_3 = new Profile()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[3].Id,
            DateHired = dateTime,
            Address = "911 Nguyen Trai",
            Ward = "An Hoa",
            City = "Hang Ma",
            State = "Hanoi City",
            PostalCode = "715000",
            Country = "Vietnam"
        };
        
        var profile_4 = new Profile()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[4].Id,
            DateHired = dateTime,
            Address = "666 Mai An Tiem",
            Ward = "An Cuu",
            City = "Hang Tre",
            State = "Vinh City",
            PostalCode = "715000",
            Country = "Vietnam"
        };
        
        var profile_5 = new Profile()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[5].Id,
            DateHired = dateTime,
            Address = "666 Le Van Viet",
            Ward = "Tan Phu",
            City = "District 9",
            State = "Ho Chi Minh City ",
            PostalCode = "715000",
            Country = "Vietnam"
        };
        
        var profile_6 = new Profile()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[6].Id,
            DateHired = dateTime,
            Address = "111 Le Van Viet",
            Ward = "Tan Hanh",
            City = "District 3",
            State = "Ho Chi Minh City ",
            PostalCode = "715000",
            Country = "Vietnam"
        };
        this.Profiles.Add(profile_0);
        this.Profiles.Add(profile_1);
        this.Profiles.Add(profile_2);
        this.Profiles.Add(profile_3);
        this.Profiles.Add(profile_4);
        this.Profiles.Add(profile_5);
        this.Profiles.Add(profile_6);
    }

    private void AddData_Attendance()
    {
        var dateTime = DateTime.UtcNow;
        var monday_morning = new DateTime(year: 2023, month: 11, day: 6, hour: 8, minute: 15, second: 10);
        var monday_afternoon = new DateTime(year: 2023, month: 11, day: 6, hour: 15, minute: 45, second: 10);
        
        var tuesday_morning = new DateTime(year: 2023, month: 11, day: 7, hour: 8, minute: 10, second: 10);
        var tuesday_afternoon = new DateTime(year: 2023, month: 11, day: 7, hour: 17, minute: 17, second: 10);
        
        var wednesday_morning = new DateTime(year: 2023, month: 11, day: 8, hour: 8, minute: 7, second: 10);
        var wednesday_afternoon = new DateTime(year: 2023, month: 11, day: 8, hour: 17, minute: 14, second: 10);
        
        var thursday_morning = new DateTime(year: 2023, month: 11, day: 9, hour: 8, minute: 9, second: 10);
        var thursday_afternoon = new DateTime(year: 2023, month: 11, day: 9, hour: 17, minute: 11, second: 10);
        
        var friday_morning = new DateTime(year: 2023, month: 11, day: 10, hour: 8, minute: 0, second: 10);
        var friday_afternoon = new DateTime(year: 2023, month: 11, day: 10, hour: 17, minute: 01, second: 10);
        
        var saturday_morning = new DateTime(year: 2023, month: 11, day: 11, hour: 7, minute: 50, second: 10);
        var saturday_afternoon = new DateTime(year: 2023, month: 11, day: 11, hour: 17, minute: 20, second: 10);
        
        var attendance_0_user_0 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = monday_morning,
            DateTimeOut = monday_afternoon,
            UserId = this.Users[0].Id
        };

        var attendance_1_user_0 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = tuesday_morning,
            DateTimeOut = tuesday_afternoon,
            UserId = this.Users[0].Id
        };
        
        var attendance_2_user_0 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = thursday_morning,
            DateTimeOut = thursday_afternoon,
            UserId = this.Users[0].Id
        };
        
        var attendance_3_user_0 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = wednesday_morning,
            DateTimeOut = wednesday_afternoon,
            UserId = this.Users[0].Id
        };
        
        var attendance_4_user_0 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = friday_morning,
            DateTimeOut = friday_afternoon,
            UserId = this.Users[0].Id
        };
        
        var attendance_5_user_0 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = saturday_morning,
            DateTimeOut = saturday_afternoon,
            UserId = this.Users[0].Id
        };

        this.Attendances.Add(attendance_0_user_0);
        this.Attendances.Add(attendance_1_user_0);
        this.Attendances.Add(attendance_2_user_0);
        this.Attendances.Add(attendance_3_user_0);
        this.Attendances.Add(attendance_4_user_0);
        this.Attendances.Add(attendance_5_user_0);
        
        var attendance_0_user_1 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = monday_morning,
            DateTimeOut = monday_afternoon,
            UserId = this.Users[1].Id
        };

        var attendance_1_user_1 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = tuesday_morning,
            DateTimeOut = tuesday_afternoon,
            UserId = this.Users[1].Id
        };
        
        var attendance_2_user_1 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = thursday_morning,
            DateTimeOut = thursday_afternoon,
            UserId = this.Users[1].Id
        };
        
        var attendance_3_user_1 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = wednesday_morning,
            DateTimeOut = wednesday_afternoon,
            UserId = this.Users[1].Id
        };
        
        var attendance_4_user_1 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = friday_morning,
            DateTimeOut = friday_afternoon,
            UserId = this.Users[1].Id
        };
        
        var attendance_5_user_1 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = saturday_morning,
            DateTimeOut = saturday_afternoon,
            UserId = this.Users[1].Id
        };

        this.Attendances.Add(attendance_0_user_1);
        this.Attendances.Add(attendance_1_user_1);
        this.Attendances.Add(attendance_2_user_1);
        this.Attendances.Add(attendance_3_user_1);
        this.Attendances.Add(attendance_4_user_1);
        this.Attendances.Add(attendance_5_user_1);
        
        var attendance_0_user_2 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = monday_morning,
            DateTimeOut = monday_afternoon,
            UserId = this.Users[2].Id
        };

        var attendance_2_user_2 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = tuesday_morning,
            DateTimeOut = tuesday_afternoon,
            UserId = this.Users[2].Id
        };
        
        var attendance_1_user_2 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = thursday_morning,
            DateTimeOut = thursday_afternoon,
            UserId = this.Users[2].Id
        };
        
        var attendance_3_user_2 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = wednesday_morning,
            DateTimeOut = wednesday_afternoon,
            UserId = this.Users[2].Id
        };
        
        var attendance_4_user_2 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = friday_morning,
            DateTimeOut = friday_afternoon,
            UserId = this.Users[2].Id
        };
        
        var attendance_5_user_2 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = saturday_morning,
            DateTimeOut = saturday_afternoon,
            UserId = this.Users[2].Id
        };

        this.Attendances.Add(attendance_0_user_2);
        this.Attendances.Add(attendance_1_user_2);
        this.Attendances.Add(attendance_2_user_2);
        this.Attendances.Add(attendance_3_user_2);
        this.Attendances.Add(attendance_4_user_2);
        this.Attendances.Add(attendance_5_user_2);
        
        var attendance_0_user_3 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = monday_morning,
            DateTimeOut = monday_afternoon,
            UserId = this.Users[3].Id
        };
        
        var attendance_1_user_3 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = thursday_morning,
            DateTimeOut = thursday_afternoon,
            UserId = this.Users[3].Id
        };
        
        var attendance_2_user_3 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = tuesday_morning,
            DateTimeOut = tuesday_afternoon,
            UserId = this.Users[3].Id
        };

        var attendance_3_user_3 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = wednesday_morning,
            DateTimeOut = wednesday_afternoon,
            UserId = this.Users[3].Id
        };
        
        var attendance_4_user_3 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = friday_morning,
            DateTimeOut = friday_afternoon,
            UserId = this.Users[3].Id
        };
        
        var attendance_5_user_3 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = saturday_morning,
            DateTimeOut = saturday_afternoon,
            UserId = this.Users[3].Id
        };

        this.Attendances.Add(attendance_0_user_3);
        this.Attendances.Add(attendance_1_user_3);
        this.Attendances.Add(attendance_2_user_3);
        this.Attendances.Add(attendance_3_user_3);
        this.Attendances.Add(attendance_4_user_3);
        this.Attendances.Add(attendance_5_user_3);
        
        var attendance_0_user_4 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = monday_morning,
            DateTimeOut = monday_afternoon,
            UserId = this.Users[4].Id
        };
        
        var attendance_1_user_4 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = thursday_morning,
            DateTimeOut = thursday_afternoon,
            UserId = this.Users[4].Id
        };
        
        var attendance_2_user_4 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = tuesday_morning,
            DateTimeOut = tuesday_afternoon,
            UserId = this.Users[4].Id
        };

        var attendance_3_user_4 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = wednesday_morning,
            DateTimeOut = wednesday_afternoon,
            UserId = this.Users[4].Id
        };
        
        var attendance_4_user_4 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = friday_morning,
            DateTimeOut = friday_afternoon,
            UserId = this.Users[4].Id
        };
        
        var attendance_5_user_4 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = saturday_morning,
            DateTimeOut = saturday_afternoon,
            UserId = this.Users[4].Id
        };

        this.Attendances.Add(attendance_0_user_4);
        this.Attendances.Add(attendance_1_user_4);
        this.Attendances.Add(attendance_2_user_4);
        this.Attendances.Add(attendance_3_user_4);
        this.Attendances.Add(attendance_4_user_4);
        this.Attendances.Add(attendance_5_user_4);
        
        var attendance_0_user_5 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = monday_morning,
            DateTimeOut = monday_afternoon,
            UserId = this.Users[5].Id
        };
        
        var attendance_1_user_5 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = thursday_morning,
            DateTimeOut = thursday_afternoon,
            UserId = this.Users[5].Id
        };
        
        var attendance_2_user_5 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = tuesday_morning,
            DateTimeOut = tuesday_afternoon,
            UserId = this.Users[5].Id
        };

        var attendance_3_user_5 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = wednesday_morning,
            DateTimeOut = wednesday_afternoon,
            UserId = this.Users[5].Id
        };
        
        var attendance_4_user_5 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = friday_morning,
            DateTimeOut = friday_afternoon,
            UserId = this.Users[5].Id
        };
        
        var attendance_5_user_5 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = saturday_morning,
            DateTimeOut = saturday_afternoon,
            UserId = this.Users[5].Id
        };

        this.Attendances.Add(attendance_0_user_5);
        this.Attendances.Add(attendance_1_user_5);
        this.Attendances.Add(attendance_2_user_5);
        this.Attendances.Add(attendance_3_user_5);
        this.Attendances.Add(attendance_4_user_5);
        this.Attendances.Add(attendance_5_user_5);
        
        var attendance_0_user_6 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = monday_morning,
            DateTimeOut = monday_afternoon,
            UserId = this.Users[6].Id
        };
        
        var attendance_1_user_6 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = thursday_morning,
            DateTimeOut = thursday_afternoon,
            UserId = this.Users[6].Id
        };
        
        var attendance_2_user_6 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = tuesday_morning,
            DateTimeOut = tuesday_afternoon,
            UserId = this.Users[6].Id
        };

        var attendance_3_user_6 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = wednesday_morning,
            DateTimeOut = wednesday_afternoon,
            UserId = this.Users[6].Id
        };
        
        var attendance_4_user_6 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = friday_morning,
            DateTimeOut = friday_afternoon,
            UserId = this.Users[6].Id
        };
        
        var attendance_5_user_6 = new Attendance()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            DateTimeIn = saturday_morning,
            DateTimeOut = saturday_afternoon,
            UserId = this.Users[6].Id
        };

        this.Attendances.Add(attendance_0_user_6);
        this.Attendances.Add(attendance_1_user_6);
        this.Attendances.Add(attendance_2_user_6);
        this.Attendances.Add(attendance_3_user_6);
        this.Attendances.Add(attendance_4_user_6);
        this.Attendances.Add(attendance_5_user_6);


    }

    private void AddData_LeaveRequest()
    {
        var dateTime = DateTime.UtcNow;
        var leaveRequest_0_user_0 = new LeaveRequest()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[0].Id,
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(2),
            TotalDay = 2

        };
        
        var leaveRequest_1_user_4 = new LeaveRequest()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[4].Id,
            StartDate = DateTime.UtcNow.AddDays(2),
            EndDate = DateTime.UtcNow.AddDays(2),
            TotalDay = 1
        };
        
        var leaveRequest_2_user_5 = new LeaveRequest()
        {
            Id = Guid.NewGuid().ToString(),
            CreatedAt = dateTime,
            LastUpdatedAt = dateTime,
            IsDeleted = false,
            UserId = this.Users[5].Id,
            StartDate = DateTime.UtcNow.AddDays(2),
            EndDate = DateTime.UtcNow.AddDays(3),
            TotalDay = 2
        };

        this.LeaveRequests.Add(leaveRequest_1_user_4);
        this.LeaveRequests.Add(leaveRequest_0_user_0);
        this.LeaveRequests.Add(leaveRequest_2_user_5);
    }
    #endregion
}
