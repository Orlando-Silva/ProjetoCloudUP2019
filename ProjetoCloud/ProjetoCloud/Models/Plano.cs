using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCloud.Models
{
    public class Plano
    {
        [Key]
        public int Id_Plano { get; set; }

        public string Nome_Plano { get; set; }

        public decimal Valor_Plano { get; set; }

        public DateTime Data_Cadastro_Plano { get; set; }

        public int Qtde_Max_Dispositivos_Plano { get; set; }
    }
}
