using ApiFilms.Data;
using ApiFilms.Respository;
using ApiFilms.Respository.IRepository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ApiFilms.FilmsMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ApiFilms.Models;

var builder = WebApplication.CreateBuilder(args);

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

//Config SQL server connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSql"));
});

//Support for authenticating with .Net Identity
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

// Add Cache
builder.Services.AddResponseCaching();

// Add repos
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IUserRepository, UserRespository>();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(FilmsMapper));

// Authentication CONFIG
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Add services to the container
builder.Services.AddControllers(options =>
{
    // Cache profile, Global Cache
    options.CacheProfiles.Add("ByDefault30Seconds", new CacheProfile() { Duration = 30});
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Define how the API will take the authentication
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
        "Authentication JWT using bearer scheme. \r\n\r\n" +
        "Type the word 'bearer' followed by a [space] and then its token in the field below \r\n\r\n" +
        "Example: \"Bearer jkbakcbsakefbs \"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


//CORS Support
// Se puede habiliar : 1-Un dominio, 2-multiples dominios, 3- cualquier dominio (Tener en cuenta la seguridad)
// Usamos de ejemplo el dominio: http://localhost3223, se debe cambiar por el correcto
// Se usa (*) para todos los dominios
builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
//Change it depending the state, if development or production
//if (app.Environment.IsDevelopment())
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// Support for CORS
app.UseCors("PolicyCors");

//app.UseCors(options =>
//{
//    options.AllowAnyOrigin();
//    options.AllowAnyMethod();
//    options.AllowAnyHeader();
//});

app.Run();
