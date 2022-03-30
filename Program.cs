using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using yadro.Areas.Identity;
using yadro.Data;
using yadro.Data.Services;
using MudBlazor.Services;
using Howler.Blazor.Components;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var services = builder.Services;
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<DataContext>(
    options => options.UseNpgsql(connectionString)
);
services.AddTransient<BlogService>();
services.AddTransient<ContentService>();
services.AddDefaultIdentity<IdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>(); 
services.AddMudServices();
services.AddScoped<IHowl, Howl>();
services.AddScoped<IHowlGlobal, HowlGlobal>();

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
