using ProjetoCloud.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCloud.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }

        public string Nome_Usuario { get; set; }

        public DateTime Data_Cadastro_Usuario { get; set; }

        public string CPF_Usuario { get; set; }

        public string Cartao_Usuario { get; set; }

        public string CEP_Usuario { get; set; }

        public bool Adm_Usuario { get; set; }

        public Plano Plano_Usuario { get; set; }

        public List<Ambiente> Ambientes_Usuario { get; set; }

        public ProjetoCloudUser UsuarioDeAutenticacao { get; set; }

        public int UsuarioDeAutenticacaoId { get; set; }

    }
}
