using Cymax.Web.BusinessService.Parcel;
using Cymax.Web.BusinessService.Services;
using Cymax.Web.DataAccess;
using Cymax.Web.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IParcelBusinessContract, ParcelBusinessService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer());

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("appDbContext"));

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<FirstService>();
builder.Services.AddTransient<SecondService>();
builder.Services.AddTransient<ThirsService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.SetIsOriginAllowed(_ => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddTransient<Func<string, IService>>(serviceProvider => key =>
{

    return key switch
    {
        "Amazon" => serviceProvider.GetService<SecondService>(),
        "Microsoft" => serviceProvider.GetService<SecondService>(),
        "Ebay" => serviceProvider.GetService<SecondService>(),
        _ => serviceProvider.GetService<SecondService>()
    };

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name:"apis" , pattern:"api/[controller]/[action]");
//});


app.Run();
