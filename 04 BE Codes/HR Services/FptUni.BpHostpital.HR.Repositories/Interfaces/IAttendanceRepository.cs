using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.Repositories;

namespace FptUni.BpHostpital.HR.Repositories;

public interface IAttendanceRepository : IBaseRepository<Attendance, HrDbContext>
{
}
