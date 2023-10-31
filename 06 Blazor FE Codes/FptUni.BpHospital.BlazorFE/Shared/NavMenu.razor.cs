﻿namespace FptUni.BpHospital.BlazorFE.Shared;

public partial class NavMenu
{
	#region [ Properties ]
	public bool ExpandSubMenu { get; set; }
	#endregion

	#region [ Methods -  ]
	public void ChangeExpandSubMenu()
	{
		this.ExpandSubMenu = !ExpandSubMenu;
	}
	#endregion
}
