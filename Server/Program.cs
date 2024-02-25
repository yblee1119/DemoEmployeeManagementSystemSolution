using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.Data;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using ServerLibrary.Repositories.Implementations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//2:25:00
builder.Services.Configure<JwtSection>(builder.Configuration.GetSection("JwtSection"));
var jwtSection = builder.Configuration.GetSection(nameof(JwtSection)).Get<JwtSection>();

//starting
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException(" Sorry, your connection is not found"));
});

// 2:23:56
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = jwtSection!.Issuer,
        ValidAudience = jwtSection.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.Key!))
    };
});


builder.Services.AddScoped<IUserAccount, UserAccountRepository>();

// 2:01:10  Client > Properties > launchSettings.json 을 참조하여 포트번호 확인
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWasm",
        builder => builder
        .WithOrigins("http://localhost:5206", "https://localhost:7268")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 2:02:28
app.UseCors("AllowBlazorWasm");

// 2:23:40
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
