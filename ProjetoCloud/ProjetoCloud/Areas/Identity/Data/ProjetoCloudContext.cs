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
        }
    }
}
