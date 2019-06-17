using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoCloud.Areas.Identity.Data;

namespace ProjetoCloud.Models
{
    public class ProjetoCloudContext : IdentityDbContext<ProjetoCloudUser>
    {
        public ProjetoCloudContext(DbContextOptions<ProjetoCloudContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProjetoCloudUser>().HasOne(pcu => pcu.UsuarioDeAplicacao)
                                                .WithOne(u => u.UsuarioDeAutenticacao);


        }
    }
}
