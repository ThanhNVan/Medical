﻿using System.Threading.Tasks;
using FptUni.BpHostpital.HR.Utils;
using ShareLibrary.EntityProviders;

namespace FptUni.BpHospital.HttpClientProviders;

public interface IProfileHttpClientProviders : IBaseProvider<Profile>
{
	#region [ Single ]
	Task<Profile> GetSingleByUserIdAsync(string userId);	
	#endregion
}
