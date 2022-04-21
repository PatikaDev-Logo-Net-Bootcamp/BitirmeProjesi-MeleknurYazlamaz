using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using InvoiceManagement.DataAccess.Concretes.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InvoiceManagement.Core.Utilities.Extensions;
using InvoiceManagement.Core.Utilities.IoC;
using InvoiceManagement.Business.DependencyResolvers;
using InvoiceManagement.Core.DependencyResolvers;

namespace InvoiceManagement.Business
{
    public class BusinessStartup
    {
        public IConfiguration Configuration { get; }
        public BusinessStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InvoiceManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("localServer")));
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new BusinessModule(),
                new CoreModule()
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidAudience = Configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

        }

    }
}
