using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Data.SerializedData.Repositories;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Interfaces.Repositories;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;
using System;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Tests.RepositoryTests
{
    [TestClassAttribute]
    public class PrinterRepositoryDatabaseTest
    {
        private IPrinterRepository printerRepository { get; set; }

        public PrinterRepositoryDatabaseTest()
        {
            printerRepository = new PrinterRepository();
        }

        [TestMethod]
        public void PrinterRepository__Add__Success()
        {
            var x = GetGenericPrinter();

            x.SerialNumber += x.Id;

            printerRepository.Add(x);

            var y = printerRepository.GetById(x.Id);

            x.Should().Be(y);
            x.SerialNumber.Should().Be(y.SerialNumber);
        }

        [TestMethod]
        public void PrinterRepository__Crud__Test()
        {
            var ip = "192.168.0.1";

            var x = GetGenericPrinter(ip);

            x.SerialNumber += x.Id;

            printerRepository.Add(x);

            var result = printerRepository.GetById(x.Id);

            result.Model = "New Model";

            printerRepository.Update(result);

            result.Should().NotBe(x);

            printerRepository.Remove(result.Id);

            var result2 = printerRepository.GetById(x.Id);

            result2.Should().Be(null);
        }

        [TestMethod]
        public void PrinterRepository__Loop10_000Crud__Test()
        {
            for (int i = 0; i < 10_000; i++)
            {

                var ip = "192.168.0.1";

                var x = GetGenericPrinter(ip);

                x.SerialNumber += x.Id;

                printerRepository.Add(x);

                var result = printerRepository.GetById(x.Id);

                result.Model = "New Model";

                printerRepository.Update(result);

                result.Should().NotBe(x);

                printerRepository.Remove(result.Id);

                var result2 = printerRepository.GetById(x.Id);

                result2.Should().Be(null);
            }
        }

        private Printer GetGenericPrinter(string ipAddress = "127.0.0.1")
        {
            return new Printer
            {
                Id = Guid.NewGuid(),
                IpAddress = ipAddress,
                MacAddress = "00:00:00:00:00",
                Manufacturer = "Default",
                Model = "Tipo",
                SerialNumber = "Serial"
            };
        }
    }
}
