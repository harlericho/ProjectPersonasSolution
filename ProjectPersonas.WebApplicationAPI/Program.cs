using ProjectPersonas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ProjectPersonas.Domain.Repositories;
using ProjectPersonas.Infrastructure.Repositories;
using ProjectPersonas.Application.Services;
using ProjectPersonas.Domain.Security;
using ProjectPersonas.Infrastructure.Security;
using ProjectPersonas.Application.Validatiors;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

// DbContext SQL Server
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
// Servicios
builder.Services.AddScoped<EspecialidadService>();
builder.Services.AddScoped<PersonaService>();
builder.Services.AddScoped<AuthService>();

// Seguridad
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<ITokenService, TokenService>();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePersonaValidator>();

// Auth JWT
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
        //  Aquí agregamos el mensaje personalizado
        //options.Events = new JwtBearerEvents
        //{
        //    OnChallenge = context =>
        //    {
        //        // Evita que se ejecute la respuesta predeterminada (401 vacía)
        //        context.HandleResponse();

        //        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //        context.Response.ContentType = "application/json";

        //        var result = System.Text.Json.JsonSerializer.Serialize(new
        //        {
        //            success = false,
        //            message = "El token es requerido o inválido"
        //        });

        //        return context.Response.WriteAsync(result);
        //    }
        //};
        options.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                // Evita la respuesta predeterminada 401
                context.HandleResponse();

                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    var result = System.Text.Json.JsonSerializer.Serialize(new
                    {
                        success = false,
                        message = "El token es requerido o inválido"
                    });

                    return context.Response.WriteAsync(result);
                }

                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                if (context.Exception is SecurityTokenExpiredException)
                {
                    if (!context.Response.HasStarted)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";

                        var result = System.Text.Json.JsonSerializer.Serialize(new
                        {
                            success = false,
                            message = "El token ha expirado"
                        });

                        return context.Response.WriteAsync(result);
                    }
                }

                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
