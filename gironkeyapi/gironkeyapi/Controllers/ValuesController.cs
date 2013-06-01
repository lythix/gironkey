﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace gironkeyapi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // GET /api/values?latitude=lat&longitude=long
        public string Get(string latitude, string longitude)
        {
            var serializer = new JavaScriptSerializer();

            var dto = new PropertyDto();
            dto.Latitude = latitude;
            dto.Longitude = longitude;

            return serializer.Serialize(dto);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class PropertyDto
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}