using aslanbetjetBusiness.Abstract;
using aslanbetjetBusiness.Concrete;
using Aslanbeyjetdata.Abstract;
using Aslanbeyjetdata.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBiletRepository, EfCoreBiletRepository>();

builder.Services.AddScoped<IBiletService, BiletManager>();
builder.Services.AddScoped<IGuzergahRepository, EfCoreGuzergahRepository>();
builder.Services.AddScoped<IGuzergahService, GuzergahManager>();
builder.Services.AddScoped<ISehirRepository, EfCoreSehirRepository>();
builder.Services.AddScoped<ISehirService, SehirManager>();
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
