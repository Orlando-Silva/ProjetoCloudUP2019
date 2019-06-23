using DAL.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCloud.ViewModels
{
    public class ViewModelEditarUsuario
    {
        public SelectList Planos { get; set; }
        public Usuario Usuario { get; set; }
        public int PlanoSelecionado { get; set; }
    }
}
