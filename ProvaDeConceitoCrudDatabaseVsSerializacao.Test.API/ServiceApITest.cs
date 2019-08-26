using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models;
using ProvaDeConceitoCrudDatabaseVsSerializacao.Service.API;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Test.API
{
    public class ServiceApITest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;


        public ServiceApITest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/api/printer")]
        public async Task ServiceApI__AddPrinter__Success(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        private static string GetPrinterJson()
        {
            return JsonConvert.SerializeObject(new Printer { Id = Guid.NewGuid(), IpAddress = "string", MacAddress = "string", Manufacturer = "string", Model = "string", SerialNumber = "string" });
        }
    }
}
