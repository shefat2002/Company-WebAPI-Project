using AenEnterprise.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApplicationProduct.Features.DataAccess.MicroServiceDbContext;
using WebApplicationProduct.Features.DataAccess.Repositories;
using WebApplicationProduct.Features.DataAccess.RepositoryInterface;
using WebApplicationProduct.Features.ServiceImplementation;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface;
using WebApplicationProduct.Features.ServiceImplementation.ServiceInterface.ViewMapper;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
.WriteTo.Console()
.WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
.CreateLogger();
builder.Host.UseSerilog();
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

builder.Services.AddControllers();

builder.Services.AddDbContext<CompanyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyDbConnectionString")));
//Company
//builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
//builder.Services.AddTransient<ICompanyService, CompanyService>();
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

//Automapper Service
builder.Services.AddAutoMapper(typeof(CompanyPrfile));


// Add services to the container.

var app = builder.Build();


app.UseRouting();
app.MapControllers();
 
app.Run();
 