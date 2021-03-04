namespace Alterdata.Bimer.WebAPI.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Alterdata.Bimer.Core.Repositorio;
    using Alterdata.Bimer.Core.Repositorio.Impl;
    using Alterdata.Bimer.Core.Servico;
    using Alterdata.Bimer.Core.Servico.Impl;
    using Alterdata.Bimer.WebAPI.ServicoAplicacao;
    using Alterdata.Bimer.WebAPI.ServicoAplicacao.Impl;
    using core.Modelo.Auth;
    using core.Repository;
    using core.Repository.Context;
    using core.Repository.Impl;
    using core.Services;
    using core.Services.Impl;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Npgsql;
    using web.api.Configuracao;
    using web.api.ServicoAplicacao;
    using web.api.ServicoAplicacao.Impl;

    public static class Configuracao
    {
        public static IServiceCollection InjetarDependenciasCore(this IServiceCollection services, IConfiguration configuration, JwtConfiguracao jwt)
        {

            services.AddDbContext<APIClienteContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("SqlServer")), ServiceLifetime.Scoped
                   );

            services.AddIdentity<Usuario, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 0;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Lockout.AllowedForNewUsers = false;
                    
                })
                .AddEntityFrameworkStores<APIClienteContext>()
                .AddDefaultTokenProviders();

            
            //services.AddScoped<IDbConnection, NpgsqlConnection>(provider => new NpgsqlConnection(configuration.GetConnectionString("PostgreSql")));
            // TODO você pode utilizar também o SQL Server comentando descomentando a linha abaixo!
            
            services.AddScoped<IDbConnection, SqlConnection>(provider => new SqlConnection(configuration.GetConnectionString("SqlServer")));
            
            services.AddScoped<IServicoAplicacaoEmpresa, ServicoAplicacaoEmpresa>();
            services.AddScoped<IServicoDominioEmpresa, ServicoDominioEmpresa>();
            services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();

            services.AddScoped<IServicoAplicacaoCliente, ServicoAplicacaoCliente>();

            
            services.AddScoped(typeof(IServicoDominioCliente), typeof(ServicoDominioCliente));
            services.AddScoped(typeof(IRepositorioCliente), typeof(RepositorioCliente));

            services.AddScoped(typeof(IServicoDominioContato), typeof(ServicoDominioContato));
            services.AddScoped(typeof(IRepositorioContato), typeof(RepositorioContato));

            return services;
        }

        public static IServiceCollection InjetarSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AlterData", Version = "v1" });
                
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.
                    No Campo Value, Coloque Bearer + token gerado pelo Login, 
                    Exemplo: 'Bearer 123'
                    123 seria o Token gerado pela Api no Login !",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                var security =
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                },
                                UnresolvedReference = true
                            },
                            new List<string>()
                        }
                    };
                options.AddSecurityRequirement(security);
            });

            return services;
        }
        

        public static IServiceCollection Auth(this IServiceCollection services, JwtConfiguracao jwtSettings)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }
    }
}