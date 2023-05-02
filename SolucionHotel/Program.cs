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
builder.Services.AddRazorPages();

//DI
builder.Services.AddDbContext<DbContext, HotelDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("hotelsSql")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IGenericRepository<Hotel>, GenericRepository<Hotel>>();
builder.Services.AddTransient<IGenericRepository<Room>, GenericRepository<Room>>();

builder.Services.AddScoped<ICreateService<DTOHotelSave>, HotelService>();
builder.Services.AddScoped<IGetService<DTOHotelGet>, HotelService>();
builder.Services.AddScoped<IUpdateService<DTOHotelSave>, HotelService>();
builder.Services.AddScoped<IDeleteService, HotelService>();

builder.Services.AddScoped<ICreateService<DTORoomSave>, RoomService>();
builder.Services.AddScoped<IGetByIdService<DTORoomGet>, RoomService>();
builder.Services.AddScoped<IUpdateService<DTORoomSave>, RoomService>();
builder.Services.AddScoped<IDeleteService, RoomService>();

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
