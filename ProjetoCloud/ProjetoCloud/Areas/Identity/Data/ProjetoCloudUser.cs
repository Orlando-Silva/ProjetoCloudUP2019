using DAL.Entidades;
using Microsoft.AspNetCore.Identity;

namespace ProjetoCloud.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ProjetoCloudUser class
    public class ProjetoCloudUser : IdentityUser
    {
        public int UsuarioId { get; set; }
    }
}
