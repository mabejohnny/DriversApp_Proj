using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TruckDriverApp.Interfaces;
using TruckDriverApp.Models;

namespace TruckDriverApp.Services
{
    public class GeocodingServicecs : IGeocodingService
    {
        public async Task<Facility> AttachLatAndLong(Facility facility)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={facility.Address}+{facility.City}+{facility.State}&key={APIKeys.GOOGLE_API_KEY}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();

            JObject jObject = JObject.Parse(jsonResult);
            facility.Latitude = (double)jObject["results"][0]["geometry"]["location"]["lat"];
            facility.Longitude = (double)jObject["results"][0]["geometry"]["location"]["lng"];

            return facility;
        }
    }
}
