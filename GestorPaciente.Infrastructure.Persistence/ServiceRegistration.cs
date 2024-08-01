using GestorPaciente.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Infrastructure.Persistence
{
    
    // Extension Method - Decorator Pathern

    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            #region Context
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<GestorPacienteContext>(option => option.UseInMemoryDatabase("ApplicacionDb"));
            }
            else
            {
                services.AddDbContext<GestorPacienteContext>
                    (options => options.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                            m => m.MigrationsAssembly(typeof(GestorPacienteContext).Assembly.FullName)
                        )
                     );
            }
            #endregion

        }
    }
}
