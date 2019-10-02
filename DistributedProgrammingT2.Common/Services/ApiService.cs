using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DistributedProgrammingT2.Common.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace DistributedProgrammingT2.Common.Services
{
    class ApiService : IApiService
    {
        public async Task<bool> CheckConnection(string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return false;
            }

            return await CrossConnectivity.Current.IsRemoteReachable(url);
        }

        public async Task<Response<CountriesResponse>> GetCountries(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var request = "";
                var requestString = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<CountriesResponse>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var countries = JsonConvert.DeserializeObject<CountriesResponse>(result);
                return new Response<CountriesResponse>
                {
                    IsSuccess = true,
                    Result = countries 
                };
            }
            catch (Exception ex)
            {
                return new Response<CountriesResponse>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


    }

}