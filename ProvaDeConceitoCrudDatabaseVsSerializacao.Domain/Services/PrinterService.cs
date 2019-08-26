using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Services;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Services
{
    public class PrinterService : ServiceBase<Printer>, IPrinterService
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterService(IPrinterRepository printerRepository):base(printerRepository)
        {
            _printerRepository = printerRepository;
        }

        public Printer FindByIpAddress(string ipAddress)
        {
            return _printerRepository.FindByIpAddress(ipAddress);
        }
    }
}
