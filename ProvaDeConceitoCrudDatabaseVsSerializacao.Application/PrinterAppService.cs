using ProvaDeConceitoCrudDatabaseVsSerializacao.Application.Interfaces;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Services;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Application
{
    public class PrinterAppService : AppServiceBase<Printer>, IPrinterAppService
    {
        private readonly IPrinterService _printerAppService;

        public PrinterAppService(IPrinterService printerAppService) : base(printerAppService)
        {
            _printerAppService = printerAppService;
        }

        public Printer FindByIpAddress(string ipAddress)
        {
            return _printerAppService.FindByIpAddress(ipAddress);
        }
    }
}
