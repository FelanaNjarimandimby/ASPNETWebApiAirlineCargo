using Microsoft.EntityFrameworkCore;
using R�servationApp;
using R�servationApp.Data;
using R�servationApp.Interfaces;
using R�servationApp.Repository;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using R�servationApp.Models.Mod�leLogin;
using R�servationApp.Models;
using Microsoft.AspNetCore.Identity;
using R�servationApp.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAeroportRepository, AeroportRepository>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IAvionCargoRepository, AvionCargoRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICompagnieRepository, CompagnieRepository>();
builder.Services.AddScoped<ICoutFretRepository, CoutFretRepository>();
builder.Services.AddScoped<IEscaleRepository, EscaleRepository>();
builder.Services.AddScoped<IItineraireRepository, ItineraireRepository>();
builder.Services.AddScoped<ILtaRepository, LtaRepository>();
builder.Services.AddScoped<IMarchandiseRepository, MarchandiseRepository>();
builder.Services.AddScoped<INature_MarchandiseRepository, Nature_MarchandiseRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ITypeTarifRepository, TypeTarifRepository>();
builder.Services.AddScoped<IVenteRepository, VenteRepository>();
builder.Services.AddScoped<IVolCargoRepository, VolCargoRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IReservationClientRepository, ReservationClientRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<JwtService>();

//builder.Services.AddScoped<ITypeTarifRepository, TypeTarifRepository>();

builder.Services.AddScoped<IExempleRepository, ExempleRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IRefreshTokenGenerator, RefreshTokenGenerator>();


//Get JWTsetting
var _dbcontext = builder.Services.BuildServiceProvider().GetService<DataContext>();
builder.Services.AddSingleton<IRefreshTokenGenerator>(provider => new RefreshTokenGenerator(_dbcontext));

var _jwtsetting = builder.Configuration.GetSection("JWTSetting");
builder.Services.Configure<JWTSetting>(_jwtsetting);

var authkey = builder.Configuration.GetValue<string>("JWTSetting:securitykey");

builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{

    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authkey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew=TimeSpan.Zero
    };
});


//Enable CORS
builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

//JSON Serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Authentification
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
