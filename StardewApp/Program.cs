using StardewApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using StardewApp.Repositories;
using StardewApp.Interfaces;
using StardewApp.Services;
using StardewApp.Mappings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=stardew.db"));
builder.Services.AddScoped<IUserCropRepository, UserCropRepository>();
builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<ISettingRepository, SettingRepository>();
builder.Services.AddScoped<IUserCropService, UserCropService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<IFertilizerMultiplierRepository, FertilizerMultiplierRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();





app.Run();

