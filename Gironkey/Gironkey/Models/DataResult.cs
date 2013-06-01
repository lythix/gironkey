using System;

namespace Gironkey.Models
{
    public class DataResult
    {
        public Guid Id { get; set; }
        public string HouseNumber { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string SquareMeterSize { get; set; }
        public string ZoneCode { get; set; }
    }
}