namespace FptUni.BpHospital.HttpClientProviders;

public class HttpClientContext
{

	#region [ CTor ]
	public HttpClientContext(IAuthenticationHttpClientProviders authentication,
							IUserHttpClientProviders user)
	{
        Authentication = authentication;
        User = user;
    }

    #endregion

	#region [ Properties ]
    public IAuthenticationHttpClientProviders Authentication { get; }
    public IUserHttpClientProviders User { get; }
    #endregion
}
