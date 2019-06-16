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

        public int CEP_Usuario { get; set; }

        public string Email_Usuario { get; set; }

        public string Senha_Usuario { get; set; }

        public Boolean Adm_Usuario { get; set; }

        public Plano Plano_Usuario { get; set; }

        public List<Ambiente> Ambientes_Usuario { get; set; }
    }
}
