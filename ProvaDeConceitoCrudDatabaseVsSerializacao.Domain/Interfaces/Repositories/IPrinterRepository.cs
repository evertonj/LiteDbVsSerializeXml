using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories
{
    public interface IPrinterRepository : IRepository<Printer>
    {
        Printer FindByIpAddress(string ipAddress);
    }
}
