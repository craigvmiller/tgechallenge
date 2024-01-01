using Newtonsoft.Json.Linq;
using TGEChallengeApp.Interfaces;

namespace TGEChallengeApp.DataAccess
{
    internal class PostcodeManager : IPostcodeManager
    {
        private readonly ITGEChallengeAPIService _api;

        public PostcodeManager(ITGEChallengeAPIService api)
        {
            _api = api;
        }

        public IEnumerable<string> GetAllPostcodes()
        {
            List<string> allPostcodes = new List<string>();
            var response = _api.Get();
            if (!response.IsSuccess)
            {
                return allPostcodes;
            }

            JArray jsonResult = JArray.Parse(response.JSONData);
            allPostcodes.AddRange(jsonResult.Select(jsonObject => $"{jsonObject}"));
            return allPostcodes;
        }

        public async Task AddNewPostcodes(IEnumerable<string> postcodes)
        {
            var response = await _api.PostAsync(postcodes);
        }

        public void DeletePostcode(string postcodeToDelete)
        {
            var response = _api.Delete(postcodeToDelete);
        }
    }
}
