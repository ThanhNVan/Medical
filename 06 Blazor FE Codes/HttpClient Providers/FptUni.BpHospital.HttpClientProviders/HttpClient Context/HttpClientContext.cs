namespace FptUni.BpHospital.HttpClientProviders;

public class HttpClientContext
{

	#region [ CTor ]
	public HttpClientContext(IAuthenticationHttpClientProviders authentication)
	{
        Authentication = authentication;
    }

    #endregion

	#region [ Properties ]
    public IAuthenticationHttpClientProviders Authentication { get; }
	#endregion
}
