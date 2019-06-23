using DAL.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCloud.DTO
{
    public class DispositivoDTO
    {
        public int Id_Dispositivo { get; set; }

        public string Nome_Dispositivo { get; set; }

        public DateTime Data_Cadastro_Dispositivo { get; set; }

        public bool Status_Dispositivo { get; set; }

        public Ambiente Ambiente { get; set; }

        [Remote(action: "ValidateDispositivo", controller: "Dispositivos", AdditionalFields = nameof(nome_ambiente))]
        public string nome_ambiente { get; set; }
    }
}
