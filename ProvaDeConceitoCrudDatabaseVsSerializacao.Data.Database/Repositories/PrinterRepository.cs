using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;
using System.Linq;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Data.Database.Repositories
{
    public class PrinterRepository : Repository<Printer>, IPrinterRepository
    {
        public Printer FindByIpAddress(string ipAddress)
        {
            return LiteCollection.Find(x => x.IpAddress == ipAddress).FirstOrDefault();
        }
    }
}
