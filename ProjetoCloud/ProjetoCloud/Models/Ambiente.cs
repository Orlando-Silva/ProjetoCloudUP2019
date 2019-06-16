using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCloud.Models
{
    public class Ambiente
    {
        [Key]
        public int Id_Ambiente { get; set; }

        public string Nome_Ambiente { get; set; }

        public DateTime Data_Cadastro_Ambiente { get; set; }

        public int Qtda_Dispositivo_Ambiente { get; set; }

        public List<Dispositivo> Dispositivos_Ambiente { get; set; }
    }
}
