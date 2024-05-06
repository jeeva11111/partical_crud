using Microsoft.EntityFrameworkCore;
using partical_crud.Data;
//using partical_crud.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServerLink")));

//builder.Services.AddScoped<PhoneService, PhoneService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCors(x => x.AddPolicy("policy", x =>
{
    x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
}));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DropDown}/{action=Index}/{id?}");

app.Run();