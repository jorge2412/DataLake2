using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Factoid.Services.Background.Helpers
{
    internal static class FactHelper
    {
        internal async static Task<string> GetFactAsync()
        {
            string fact = null;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(new Uri("https://traininglabservices.azurewebsites.net/api/Facts/1"));

                fact = JsonConvert.DeserializeObject<string>(response);
            }

            return fact;
        }
    }
}
