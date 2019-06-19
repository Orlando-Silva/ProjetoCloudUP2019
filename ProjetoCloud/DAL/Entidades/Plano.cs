using System;
using System.Collections.Generic;

namespace DAL.Entidades
{
    public class Plano
    {

        public int Id_Plano { get; set; }

        public string Nome_Plano { get; set; }

        public decimal Valor_Plano { get; set; }

        public DateTime Data_Cadastro_Plano { get; set; }

        public int Qtde_Max_Dispositivos_Plano { get; set; }

        public List<Usuario> UsuariosNoPlano { get; set; }
    }
}
