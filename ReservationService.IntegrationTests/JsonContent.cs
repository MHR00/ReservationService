﻿using Newtonsoft.Json;
using System.Text;

namespace ReservationService.IntegrationTests
{
    internal class JsonContent: StringContent
    {
        public JsonContent(object obj):base(JsonConvert.SerializeObject(obj), Encoding.UTF8 , "application/json")
        {

        }
    }
}
