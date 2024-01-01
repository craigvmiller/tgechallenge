using TGEChallengeApp.Models;

namespace TGEChallengeApp.Interfaces
{
    public interface IPostcodeProcessor
    {
        IEnumerable<PostcodeDistrict> Process(IEnumerable<string> postcodes);
    }
}
