using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using RelacionamentoPadaria.Data.Repository;
using RelacionamentoPadaria.IoC;
using RelacionamentoPadaria.Models;
using RelacionamentoPadaria.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var emailConfig = builder.Configuration.GetSection("SMTP")
                                       .Get<EmailServerConfig>();

builder.Services.AddSingleton<IEmailServerConfig>(emailConfig);
builder.Services.AddTransient<EmailEnderecoModel>();
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AdicionarIoC(builder.Configuration);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.LoginPath = new PathString("/Login/Index");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Feedback}/{action=Index}/{id?}");

app.Run();
