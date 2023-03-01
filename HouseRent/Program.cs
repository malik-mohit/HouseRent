using ServiceLayer.Interface;
using ServiceLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

/////////////////////////////////////////////// Dependency Injection //////////////////////////////////////

//Services
builder.Services.AddTransient<ICommonService>(x => new CommonService(connectionString));
builder.Services.AddTransient<IUserService>(x => new UserService(connectionString));

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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HouseRent}/{action=Index}/{id?}"
    );

app.Run();
