using System;
using System.Collections.Generic;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Domain.Models
{
    public class Printer:Base
    {
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Printer printer &&
                   this.Id.Equals(printer.Id) &&
                   this.IpAddress == printer.IpAddress &&
                   this.MacAddress == printer.MacAddress &&
                   this.SerialNumber == printer.SerialNumber &&
                   this.Model == printer.Model &&
                   this.Manufacturer == printer.Manufacturer;
        }

        public override int GetHashCode()
        {
            var hashCode = 2116518946;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(this.Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.IpAddress);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.MacAddress);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.SerialNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Model);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Manufacturer);
            return hashCode;
        }
    }
}
