namespace TGEChallengeApp.Interfaces
{
    public interface IPostcodeManager
    {
        IEnumerable<string> GetAllPostcodes();
        Task AddNewPostcodes(IEnumerable<string> postcodes);
        void DeletePostcode(string postcodeToDelete);
    }
}
