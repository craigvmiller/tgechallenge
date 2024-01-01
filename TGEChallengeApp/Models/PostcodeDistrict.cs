namespace TGEChallengeApp.Models
{
    public class PostcodeDistrict
    {
        public PostcodeDistrict()
        {
            Postcodes = new List<Postcode>();
        }

        public string Name { get; set; }
        public List<Postcode> Postcodes { get; set; }
    }
}
