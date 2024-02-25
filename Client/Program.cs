using Blazored.LocalStorage;
using Client;
using Client.ApplicationStates;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using ClientLibrary.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 2:47:32
builder.Services.AddTransient<CustomHttpHandler>();

// 2:15:30  2:47:14
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7058");
}).AddHttpMessageHandler<CustomHttpHandler>();

//  2:00:35 추가   2:15:43 수정
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7058") });

//추가 1:59:21
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
// 2:16:10 즈음에 chatGPT 도움으로 아래라인 추가
builder.Services.AddScoped<CustomAuthenticationStateProvider>();

//3:58:02
builder.Services.AddScoped<DepartmentState>();  //using Client.ApplicationStates;

// 3:25:47
builder.Services.AddSyncfusionBlazor();

// 3:21:21
builder.Services.AddScoped<SfDialogService>();

await builder.Build().RunAsync();
