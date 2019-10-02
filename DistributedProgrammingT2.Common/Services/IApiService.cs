using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DistributedProgrammingT2.Common;
using DistributedProgrammingT2.Common.Models;


namespace DistributedProgrammingT2.Common.Services
{
    public interface IApiService
    {

        Task<Response<CountriesResponse>> GetCountries(string urlBase,string servicePrefix,string controller);

        Task<bool> CheckConnection(string url);

    }
}
