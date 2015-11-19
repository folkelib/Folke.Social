# Folke.Social
Fetch data from social networks (only Facebook in the current version, other identity providers are coming).

## Usage

```cs
services.AddFacebookSocial(options =>
{
	options.AppSecret = "xxx";
	options.AppId = "xxxx;
});
```
Then add a `IEnumerable<ISocialGraph>` parameter to your service or controller constructor to
have a reference to all the identity providers that you added.

```cs
public class SampleService
{
	private IEnumerable<ISocialGraph> identityProviders;

	public SampleService(IEnumerable<ISocialGraph> identityProviders)
	{
		this.identityProviders = identityProviders;
	}
	
	public async Task<string> GetFirstName(string userId, ProviderType providerType)
	{
		var provider = identityProviders.First(x => x.Type == providerType);
		return (await provider.GetIdentityAsync(userId)).FirstName;
	}	 
}
```

