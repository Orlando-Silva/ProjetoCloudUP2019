using System;
using System.Collections.Generic;

namespace DAL.Entidades
{
    public class Ambiente
    {
        public int Id_Ambiente { get; set; }

        public string Nome_Ambiente { get; set; }

        public DateTime Data_Cadastro_Ambiente { get; set; }

        public int Qtda_Dispositivo_Ambiente { get; set; }

        public List<Dispositivo> Dispositivos_Ambiente { get; set; }

        public Usuario Usuario { get; set; }
    }
}
