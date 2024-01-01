using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using TGEChallengeApp.Core.Models.API;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using TGEChallengeApp.Interfaces;

namespace TGEChallengeApp.DataAccess.API
{
    internal class TGEChallengeAPIService : ITGEChallengeAPIService
    {
        private static DummyTGEChallengeAPI _dummyAPI;

        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        static TGEChallengeAPIService()
        {
            _dummyAPI = new DummyTGEChallengeAPI();
        }

        public APIResponse Get()
        {
            var response = _dummyAPI.Get();
            return response;
        }

        public async Task<APIResponse> PostAsync(IEnumerable<string> data)
        {
            var response = await _dummyAPI.PostAsync(data);
            return response;
        }

        public APIResponse Delete(string postcodeToDelete)
        {
            var response = _dummyAPI.Delete(postcodeToDelete);
            return response;
        }
    }
}
