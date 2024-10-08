using CopyrightObjectSearch.Server;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("CopyrightObjectSearch.Server starting");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("CopyrightObjectSearch.Server adding DbContext");
builder.Services.AddDbContext<CopyrightObjectSearchDbContext>(
    options => options.UseSqlServer("name=ConnectionStrings:CopyrightObjectSearch")
);

Console.WriteLine("CopyrightObjectSearch.Server adding CORS");
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //policy.WithOrigins("https://localhost:4200").WithMethods("POST", "DELETE", "GET");
        });
});

builder.Services.AddTransient<SearchEngineRqHandler, SearchEngineRqHandler>();
builder.Services.AddTransient<UserAdministrationRqHandler, UserAdministrationRqHandler>();

Console.WriteLine("CopyrightObjectSearch.Server building application");

WebApplication app;

app = builder.Build();

Console.WriteLine("CopyrightObjectSearch.Server configuring application");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.MapFallbackToFile("/index.html");

Console.WriteLine("CopyrightObjectSearch.Server initialized");

app.Run();
