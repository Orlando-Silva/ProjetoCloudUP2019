using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCloud.Models
{
    public class Dispositivo
    {
        [Key]
        public int Id_Dispositivo { get; set; }

        public string Nome_Dispositivo { get; set; }

        public DateTime Data_Cadastro_Dispositivo { get; set; }

        public Boolean Status_Dispositivo { get; set; }
    }
}
