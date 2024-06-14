using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using WebApplication1;
using WebApplication1.Data;
using WebApplication1.IServices;
using WebApplication1.Services;


var builder = WebApplication.CreateBuilder(args);

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>(); // Konfiguracija JWT parametara, hvata vrednosti za issuer i za key iz appsettings.json
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(obj => // dodavanje autentifikacjijsih servisa i postavlja semu autentifikacije na jwtBearerDefaults.AutenthicationScheme // konfiguracija authentication servicea
{
    obj.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // omogucava koriscenje jwt tokena u autentifikaciji
    obj.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    obj.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtOptions => // konfiguracija JWT bearer autentifikacije
{
    jwtOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new List<string>()
        }
    });
});
// Add services to the container.

var Configuration = builder.Configuration;
builder.Services.AddDbContext<UserDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultSQLConnection"))); //Npgsql.EntityFrameworkCore.PostgreSQL ---- nuget paket, da mozemo da koristimo postgreSql bazu

//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
////x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
//   );

builder.Services.AddControllers().AddNewtonsoftJson(x =>
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 
// sve ove app. ...metode... su deo konfiguracije HTTP request pipelinea u ASP.NET core aplikaciji

app.UseHttpsRedirection();

app.UseAuthentication();// middleware za autentifikaciju

app.UseAuthorization();// middleware za autorizaciju

//// Moraju middleware-i da se postave pre nego sto se mapiraju kontroleri u app.MapControllers();
app.MapControllers();

app.Run();
