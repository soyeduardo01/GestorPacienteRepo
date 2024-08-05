using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace GestorPaciente.Core.Application
{
    // Extension Method - Decorator Pathern
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {

            #region Services
            services.AddTransient<IPacientesService, PacientesService>();
            services.AddTransient<IMedicosService, MedicosService>();
            services.AddTransient<ICitasService, CitasService>();
            services.AddTransient<IPruebasLaboratorioService, PruebasLaboratorioService>();
            services.AddTransient<IResultadosLaboratorioService, ResultadosLaboratorioService>();
            #endregion

        }
    }
}
