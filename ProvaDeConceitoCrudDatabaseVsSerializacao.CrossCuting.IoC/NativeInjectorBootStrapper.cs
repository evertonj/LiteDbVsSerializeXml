using Microsoft.Extensions.DependencyInjection;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Application;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Application.Interfaces;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Data.Database;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Data.Database.Repositories;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Services;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Services;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.CrossCuting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPrinterRepository, PrinterRepository>();
            services.AddScoped<IPrinterService, PrinterService>();
            services.AddScoped<IPrinterAppService, PrinterAppService>();
            services.AddSingleton<LiteDataBaseContext>();
        }
    }
}
