using NUnit.Framework.Constraints;
using TGEChallengeApp.Models;

namespace TGEChallengeApp.Tests
{
    public class PostcodeProcessorTests
    {
        [Test]
        public void Process_Returns_Correct_Result()
        {
            var postcodes = new List<string> { "CH62 3NX", "CH62 4NX", "CH62 5NX", "CH44 6NH", "CH44 4NH" };
            var expected = new List<PostcodeDistrict>
            {
                new PostcodeDistrict { Name = "CH62", Postcodes = new List<Postcode> {
                    new Postcode { Name = "CH62 3NX" },
                    new Postcode { Name = "CH62 4NX" },
                    new Postcode { Name = "CH62 5NX" },
                }
                },
                new PostcodeDistrict { Name = "CH44", Postcodes = new List<Postcode>
                {
                    new Postcode { Name = "CH44 6NH"},
                    new Postcode { Name = "CH44 4NH"},
                }
                },
            };

            var processor = new PostcodeProcessor();
            var result = processor.Process(postcodes);

            CollectionAssert.AreEqual(expected.Select(x => x.Name), result.Select(x => x.Name));
        }

        [Test]
        public void Process_Removes_Invalid_Postcodes()
        {
            var postcodes = new List<string> { "CH62 3NX1122", "CH62 4NX", "CH62 5NX", "CH44 6NH", "CH444 4NH" };
            var expected = new List<PostcodeDistrict>
            {
                new PostcodeDistrict { Name = "CH62", Postcodes = new List<Postcode> {
                    new Postcode { Name = "CH62 4NX" },
                    new Postcode { Name = "CH62 5NX" },
                }
                },
                new PostcodeDistrict { Name = "CH44", Postcodes = new List<Postcode>
                {
                    new Postcode { Name = "CH44 6NH"},
                }
                },
            };

            var processor = new PostcodeProcessor();
            var result = processor.Process(postcodes);

            CollectionAssert.AreEqual(expected.Select(x => x.Name), result.Select(x => x.Name));
        }
    }
}
