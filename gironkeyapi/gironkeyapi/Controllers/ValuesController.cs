using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Script.Serialization;
using AutoMapper;
using gironkeyapi.Models;
using gironkeyapi.Services;

namespace gironkeyapi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET /api/values?latitude=lat&longitude=long
        public string Get(string latitude, string longitude)
        {
            var service = new GironkeyService();
            var result = service.CallLandgate(latitude, longitude);

            Mapper.CreateMap<Rootobject, DataResult>()
                  .ForMember(d => d.Area, m => m.MapFrom(s => s.features.First().properties.area))
                  .ForMember(d => d.Latitude, m => m.MapFrom(s => s.features.First().properties.centlat))
                  .ForMember(d => d.Longitude, m => m.MapFrom(s => s.features.First().properties.centlong));

            var dto = Mapper.Map<DataResult>(result);

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(dto);
        }

        public string Get(string latitude, string longitude, string zoning)
        {
            var service = new GironkeyService();
            var result = service.CallLandgate(latitude, longitude);

            Mapper.CreateMap<Rootobject, DataResult>()
                  .ForMember(d => d.Area, m => m.MapFrom(s => s.features.First().properties.area))
                  .ForMember(d => d.Latitude, m => m.MapFrom(s => s.features.First().properties.centlat))
                  .ForMember(d => d.Longitude, m => m.MapFrom(s => s.features.First().properties.centlong));

            var dto = Mapper.Map<DataResult>(result);

            dto.Zoning = Convert.ToInt32(zoning.Replace("R", ""));
            var area = Convert.ToDecimal(dto.Area);
            var wholeBlockSize = new decimal(10000.0 / dto.Zoning);
            dto.BlockDivision = area / wholeBlockSize;

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(dto);
        }

        // POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}