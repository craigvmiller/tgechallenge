using System.Text.RegularExpressions;
using TGEChallengeApp.Interfaces;
using TGEChallengeApp.Models;

namespace TGEChallengeApp
{
    internal class PostcodeProcessor : IPostcodeProcessor
    {
        private readonly Regex postcodeRegex = new Regex(@"[a-zA-Z]{1,2}\d{1,2}[a-zA-Z]{0,2} \d[a-zA-Z]{1,2}\b");

        public IEnumerable<PostcodeDistrict> Process(IEnumerable<string> postcodes)
        {
            var result = new List<PostcodeDistrict>();

            foreach (var postcode in postcodes)
            {
                if (!postcodeRegex.IsMatch(postcode))
                {
                    continue;
                }

                var postcodeSplit = postcode.Split(' ');
                var existing = result.SingleOrDefault(x => x.Name == postcodeSplit.First());

                if (existing != null)
                {
                    existing.Postcodes.Add(new Postcode
                    {
                        Name = postcode
                    });
                }
                else
                {
                    result.Add(new PostcodeDistrict
                    {
                        Name = postcodeSplit.First(),
                        Postcodes = new List<Postcode>
                        {
                            new Postcode { Name = postcode }
                        }
                    });
                }
            }
            return result;
        }
    }
}