using Hotels.Domain.Contracts;
using Hotels.Domain.Contracts.Repositories;
using Hotels.Domain.Entities;
using Hotels.Infrastructure.Repositories;
using Hotels.Infrastructure.ContextDB;
using Microsoft.EntityFrameworkCore;
using Hotels.Domain.Contracts.Services;
using Hotels.Application.Services;
using Hotels.Application.DTO.Request;
using Hotels.Application.DTO.Response;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI
builder.Services.AddDbContext<DbContext, HotelDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("hotelsSql")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IGenericRepository<Hotel>, GenericRepository<Hotel>>();
builder.Services.AddScoped<IGenericRepository<Room>, GenericRepository<Room>>();

builder.Services.AddScoped<ICreateService<DTOHotelNew>, HotelService>();
builder.Services.AddScoped<IGetService<DTOHotelGet>, HotelService>();
builder.Services.AddScoped<IGetByIdService<DTOHotelGet>, HotelService>();
builder.Services.AddScoped<IUpdateService<DTOHotelEdit>, HotelService>();
builder.Services.AddScoped<IDeleteService, HotelService>();

builder.Services.AddScoped<ICreateService<DTORoomNew>, RoomService>();
builder.Services.AddScoped<IGetListByIdService<DTORoomGet>, RoomService>();
builder.Services.AddScoped<IUpdateService<DTORoomEdit>, RoomService>();
builder.Services.AddScoped<IDeleteService, RoomService>();

builder.Services.AddScoped<HotelService>();
builder.Services.AddScoped<RoomService>();


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
