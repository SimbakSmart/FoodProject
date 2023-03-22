using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbFoodContext>(
   opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); }
);

builder.Services.AddIdentityCore<User>(
    opt =>
    {
        opt.User.RequireUniqueEmail = true;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireDigit = false;
        opt.Password.RequireNonAlphanumeric = false;
    }
)
.AddRoles<Role>()
.AddEntityFrameworkStores<DbFoodContext>();

builder.Services.AddCors();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

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

app.Run();
