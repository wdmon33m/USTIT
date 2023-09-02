using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using USTIT.Services.BasicDataAPI;
using USTIT.Services.BasicDataAPI.Data;
using USTIT.Services.BasicDataAPI.Extentions;
using USTIT.Services.BasicDataAPI.Repository;
using USTIT.Services.BasicDataAPI.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
});

builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(optionts =>
{
    optionts.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "University of Science & Technology Version 1",
        Description = "API to manage university system",
        TermsOfService = new Uri("https://example.com/term"),
        Contact = new OpenApiContact
        {
            Name = "Mohamed Ibrahem",
            Email = "wdmon33m@gmail.com"
        },
        License = new OpenApiLicense
        {
            Name = "Example license",
            Url = new Uri("https://example.com/license")
        }
    });
});



// Install the Microsoft.AspNetCore.Mvc.NewtonsoftJson via the NuGet package.Then, register the AddNewtonsoftJson()
//builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "USTV1");
    });
}
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "USTV1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.ApplyMigration();
app.Run();
