using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Application.Interfaces
{
    public interface IPrinterAppService : IAppServiceBase<Printer>
    {
        Printer FindByIpAddress(string ipAddress);
    }
}
