﻿using Domain.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollecttion)
        {
            serviceCollecttion.AddTransient<IUserService, UserService>();
            serviceCollecttion.AddTransient<ILoginService,LoginService>();
        }
    }
}
