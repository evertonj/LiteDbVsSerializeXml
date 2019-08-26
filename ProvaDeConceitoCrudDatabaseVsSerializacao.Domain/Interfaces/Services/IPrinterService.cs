using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Services
{
    public interface IPrinterService : IServiceBase<Printer>
    {
        Printer FindByIpAddress(string ipAddress);
    }
}
