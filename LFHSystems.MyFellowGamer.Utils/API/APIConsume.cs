using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LFHSystems.MyFellowGamer.Utils.API
{
    public static class APIConsume
    {
        //public async Task<string> ApiPostAsync(string pUrl, StringContent pContent)
        public static async Task<string> ApiPostAsync(string pUrl, StringContent pContent)
        {
            string ret = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(pUrl, pContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ret = apiResponse;
                }
            }

            return ret;
        }

        public static async Task<string> ApiGetAsync(string pUrl)
        {
            string ret = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(pUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ret = apiResponse;
                }
            }

            return ret;
        }


    }
}
