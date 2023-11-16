using System;

namespace FptUni.BpHospital.Common;

public class GetByUserIdFromAndEndDateModel
{
	#region [ Properties ]
	public string UserId { get; set; }

	public DateTime FromDate { get; set; }

	public DateTime EndDate { get; set; }
	#endregion
}
