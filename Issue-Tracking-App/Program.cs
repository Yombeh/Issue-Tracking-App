using Issue_Tracking_App.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using System.Security.Claims;
using Issue_Tracking_App.Transformer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Issue_Tracking_App.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(
builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddSingleton<MailService>();

//Claims
builder.Services.AddTransient<IClaimsTransformation, TransactionLogsClaimsTransformation>();

// Windows authentication

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin", "Yes"));
    options.AddPolicy("Developer", policy => policy.RequireClaim("Developer","Yes"));
    options.AddPolicy("Tester", policy => policy.RequireClaim("Tester","Yes"));

});


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Tracking/Dashboard");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
//app.UseMiddleware<TransactionLogsClaimsTransformation>();
app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Tracking}/{action=UserPage}/{id?}");


app.Run();
