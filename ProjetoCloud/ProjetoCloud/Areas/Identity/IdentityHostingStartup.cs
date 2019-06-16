using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoCloud.Areas.Identity.Data;
using ProjetoCloud.Models;

[assembly: HostingStartup(typeof(ProjetoCloud.Areas.Identity.IdentityHostingStartup))]
namespace ProjetoCloud.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProjetoCloudContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ProjetoCloudContextConnection")));

                services.AddDefaultIdentity<ProjetoCloudUser>()
                    .AddEntityFrameworkStores<ProjetoCloudContext>();
            });
        }
    }
}