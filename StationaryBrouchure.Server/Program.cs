using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using StationaryBrouchure.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Entity Framework Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Add distributed memory cache (required for session management)
builder.Services.AddDistributedMemoryCache(); // Required for session management

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Set session timeout
    options.Cookie.HttpOnly = true;                  // Make session cookie HTTP-only
    options.Cookie.IsEssential = true;               // Ensure cookie is marked as essential
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Shows detailed error information in Development
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Handles errors in Production
    app.UseHsts(); // Adds HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS
app.UseRouting(); // Enables routing

app.UseCors("AllowAllOrigins"); // Use CORS policy

// Add session middleware
app.UseSession();  // Enables session management

app.UseAuthorization(); // Enables authorization

app.MapControllers(); // Maps controller actions to routes

app.Run(); // Runs the application
