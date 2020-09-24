using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecurityApp1.Areas.Identity.Data;
using SecurityApp1.Data;

[assembly: HostingStartup(typeof(SecurityApp1.Areas.Identity.IdentityHostingStartup))]
namespace SecurityApp1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SecurityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SecurityDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => { options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = true;
                
                })
                    .AddEntityFrameworkStores<SecurityDbContext>();
            });
        }
    }
}