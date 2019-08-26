using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Data.SerializedData.Repositories
{
    public class PrinterRepository : Repository<Printer>, IPrinterRepository
    {
        public Printer FindByIpAddress(string ipAddress)
        {
            return Db.ReadXML().Find(x => x.IpAddress == ipAddress);
        }
    }
}
