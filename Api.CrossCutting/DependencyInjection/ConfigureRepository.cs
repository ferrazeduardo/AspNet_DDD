using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Domain.Interfaces.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollecttion, IConfiguration Configuration)
        {
            serviceCollecttion.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>));
            serviceCollecttion.AddDbContext<MyContext>(options => options.UseMySQL(Configuration.GetConnectionString("DbDDD")));

        }
    }
}
