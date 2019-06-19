using System;
using System.Collections.Generic;

namespace DAL.Entidades
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }

        public string Nome_Usuario { get; set; }

        public DateTime Data_Cadastro_Usuario { get; set; }

        public string CPF_Usuario { get; set; }

        public string Cartao_Usuario { get; set; }

        public string CEP_Usuario { get; set; }

        public Plano Plano_Usuario { get; set; }

        public List<Ambiente> Ambientes_Usuario { get; set; }
    }
}
