using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjetoCloud.Models;

namespace ProjetoCloud.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ProjetoCloudUser class
    public class ProjetoCloudUser : IdentityUser
    {

        public Usuario UsuarioDeAplicacao { get; set; }

        public int UsuarioDeAplicacaoId  { get; set; }
    }
}
