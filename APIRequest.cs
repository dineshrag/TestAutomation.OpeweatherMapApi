using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.RIT
{
    public class APIRequest
    {
        public static string responseout;
        
        /// <summary>
        /// Initiate request to the URL and get response
        /// </summary>
        /// <param name="method">Name of the API request</param>
        /// <param name="url">url</param>
        /// <returns>JSON output</returns>
        public static async Task<string> Request(string method, Uri url)
        {
            switch (method.ToLower())
            {
                case "get":
                    using (var client = new HttpClient())
                    {
                        try
                        {
                            using (var r = await client.GetAsync(url))
                            {
                                string result = await r.Content.ReadAsStringAsync();
                                return result;
                            }
                        }
                        catch(Exception e)
                        {
                            return e.ToString();
                        }
                    }
            }
            return null;
        }

    }
}

