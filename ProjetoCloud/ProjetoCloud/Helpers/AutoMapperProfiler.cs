using AutoMapper;
using ProjetoCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal.ExternalLoginModel;

namespace ProjetoCloud.Helpers
{
    public class AutoMapperProfiler
    {
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<ProjetoCloud.Areas.Identity.Pages.Account.RegisterModel.InputModel, Usuario>();
            }
        }
    }
}
