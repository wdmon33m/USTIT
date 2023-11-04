using Microsoft.AspNetCore.Authentication.Cookies;
using USTIT.WEB;
using USTIT.WEB.Areas.Auth.Services;
using USTIT.WEB.Areas.Auth.Services.IService;
using USTIT.WEB.Areas.BasicData.Services;
using USTIT.WEB.Areas.BasicData.Services.IServices;
using USTIT.WEB.Areas.HeadDepartment.Services;
using USTIT.WEB.Areas.HeadDepartment.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddHttpClient<ICourseService, CourseService>();
builder.Services.AddHttpClient<ITeacherService, TeacherService>();
builder.Services.AddHttpClient<ICourseEnrollmentService, CourseEnrollmentService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IRoleService, RoleService>();


builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<ICourseEnrollmentService, CourseEnrollmentService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    }
    );


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
