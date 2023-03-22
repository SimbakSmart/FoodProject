using API.Data;
using API.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbFoodContext>(
   opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); }
);

builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCors();
//builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddApplicationServices();

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = scope.ServiceProvider.GetRequiredService<DbFoodContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    await DbInitializer.Initializae(context, userManager);
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(environment.ContentRootPath, "wwwroot/images")),
//    // RequestPath = "/wwwroot/images"
//    RequestPath = "/Images"
//    //https://localhost:7205/Images/3a6ab638-2151-4fa0-abf6-28a96aa2a37b.jpg
//});

app.Run();
