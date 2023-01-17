using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AzureADBlazor.Client;
using AzureADBlazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("AzureADBlazor.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AzureADBlazor.ServerAPI"));

builder.Services.AddMsalAuthentication<RemoteAuthenticationState,
    CustomUserAccount>(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://ff11dedd-c49a-4ea2-9275-9538085875b7/API.Access");
    options.UserOptions.RoleClaim = "appRole";
}).AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount,
        CustomAccountFactory>();

var baseUrl = string.Join("/",
    builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"],
    builder.Configuration.GetSection("MicrosoftGraph")["Version"]);
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes")
    .Get<List<string>>();

builder.Services.AddGraphClient(baseUrl, scopes);

await builder.Build().RunAsync();
