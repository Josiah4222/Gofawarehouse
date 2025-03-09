using Gofabackend.Data;
using Gofabackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    // Configure DbContext with SQLite
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Add Identity with custom User and Role classes
    builder.Services.AddIdentity<User, Role>(options =>
    {
        // Configure Identity options if needed
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

    // Add controllers
    builder.Services.AddControllers();

    // Add JWT Authentication
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured.")))
        };
    });

    // Add CORS policy (optional, for frontend development)
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}

var app = builder.Build();

// Seed the super user during application startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<Role>>();

        // Ensure the database is created
        await context.Database.EnsureCreatedAsync();

        // Ensure the "Admin" role exists
        var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
        if (!adminRoleExists)
        {
            await roleManager.CreateAsync(new Role { Name = "Admin", NormalizedName = "ADMIN" });
        }

        // Check if the super user already exists
        var superUser = await userManager.FindByNameAsync("superuser@example.com");
        if (superUser == null)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "superuser@example.com",
                Email = "superuser@example.com",
                FirstName = "Super",
                LastName = "Admin"
            };

            // Create the super user
            var result = await userManager.CreateAsync(newUser, "SuperUserPassword123!");
            if (result.Succeeded)
            {
                // Assign the "Admin" role to the super user
                await userManager.AddToRoleAsync(newUser, "Admin");
                Console.WriteLine("Super user created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create super user:");
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }
            }
        }
        else
        {
            Console.WriteLine("Super user already exists.");
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Enable CORS (optional, for frontend development)
app.UseCors("AllowAll");

app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();