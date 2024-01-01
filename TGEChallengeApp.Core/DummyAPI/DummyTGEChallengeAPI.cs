using System.Text.Json;
using TGEChallengeApp.Core.Models.API;

namespace TGEChallengeApp.DataAccess.API
{
    public class DummyTGEChallengeAPI
    {
        private readonly string _postcodeFilePathCSV;

        public DummyTGEChallengeAPI()
        {
            _postcodeFilePathCSV = @"../../../../DataSource/postcode_data.csv";
        }

        public APIResponse Get()
        {
            var postcodeData = System.IO.File.ReadAllLines(_postcodeFilePathCSV).Skip(1).Select(line => line.Split(',')[0]);
            string jsonData = JsonSerializer.Serialize(postcodeData);

            return new APIResponse
            {
                JSONData = jsonData,
                IsSuccess = true,
            };
        }

        public async Task<APIResponse> PostAsync(IEnumerable<string> postcodes)
        {
            await System.IO.File.AppendAllLinesAsync(_postcodeFilePathCSV, postcodes);

            return new APIResponse
            {
                IsSuccess = true,
            };
        }

        public APIResponse Delete(string postcodeToDelete)
        {
            var fileLines = System.IO.File.ReadAllLines(_postcodeFilePathCSV).ToList();
            fileLines.RemoveAt(0);

            var modifiedLines = new List<string>();
            modifiedLines.Add(fileLines[0]);

            foreach (var line in fileLines)
            {
                var postcode = line.Split(',')[0];
                if (postcode != postcodeToDelete)
                {
                    modifiedLines.Add(line);
                }
            }

            System.IO.File.WriteAllLines(_postcodeFilePathCSV, modifiedLines);

            return new APIResponse
            {
                IsSuccess = true,
            };
        }
    }
}
