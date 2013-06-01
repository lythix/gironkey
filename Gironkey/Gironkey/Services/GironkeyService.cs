using System;
using Gironkey.Controllers;
using Gironkey.Models;

namespace Gironkey.Services
{
    public class GironkeyService
    {
        public DataResult GetDataForAddress(string address)
        {
            var result = new DataResult
                {
                    Id = new Guid(),
                    HouseNumber = "50",
                    AddressOne = "Address 1", 
                    AddressTwo = "Address 2",
                    Suburb = "Midland",
                    State = "WA",
                    PostCode = "6000",
                    Country = "Australia",
                    Lat = "115",
                    Long = "-35",
                    SquareMeterSize = "600",
                    ZoneCode = "R20"
                };
            return result;
        }
    }
}