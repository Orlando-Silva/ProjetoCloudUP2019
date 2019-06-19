using System;

namespace DAL.Entidades
{
    public class Dispositivo
    {
        public int Id_Dispositivo { get; set; }

        public string Nome_Dispositivo { get; set; }

        public DateTime Data_Cadastro_Dispositivo { get; set; }

        public bool Status_Dispositivo { get; set; }

        public Ambiente Ambiente { get; set; }
    }
}
