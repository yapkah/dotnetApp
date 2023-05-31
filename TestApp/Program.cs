using Microsoft.EntityFrameworkCore;
using TestApp.Model;
using TestApp.ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();

builder.Services.AddDbContextPool<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")));

//builder.Services.AddScoped<IEmployeeRepository,EmployeeViewModel>();
builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
