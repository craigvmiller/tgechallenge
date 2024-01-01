using TGEChallengeApp.Core.Models.API;

namespace TGEChallengeApp.Interfaces
{
    public interface ITGEChallengeAPIService
    {
        APIResponse Delete(string postcodeToDelete);
        APIResponse Get();
        Task<APIResponse> PostAsync(IEnumerable<string> data);
    }
}