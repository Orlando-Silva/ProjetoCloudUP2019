using AutoMapper;
using DAL.Entidades;
using ProjetoCloud.DTO;
using ProjetoCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCloud.Helpers
{
    public class AutoMapperProfiler
    {
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<ProjetoCloud.Areas.Identity.Pages.Account.RegisterModel.InputModel, DAL.Entidades.Usuario>();
                CreateMap<DispositivoDTO, Dispositivo>();
                CreateMap<Dispositivo, DispositivoDTO>();

            }
        }
    }
}
