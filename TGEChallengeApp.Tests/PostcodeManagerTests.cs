using Moq;
using TGEChallengeApp.DataAccess;
using TGEChallengeApp.Interfaces;

namespace TGEChallengeApp.Tests
{
    public class PostcodeManagerTests
    {
        private Mock<ITGEChallengeAPIService> _api;

        [SetUp]
        public void Setup()
        {
            _api = new Mock<ITGEChallengeAPIService>();
        }

        [Test]
        public void GetAllPostcodes_Returns_Correct_Result()
        {
            _api.Setup(x => x.Get()).Returns(new Core.Models.API.APIResponse { IsSuccess = true, JSONData = "[\"CH62 3NX\",\"CH44 6NH\"]" });
            var postcodeManager = new PostcodeManager(_api.Object);

            var expected = new List<string> { "CH62 3NX", "CH44 6NH" };
            var result = postcodeManager.GetAllPostcodes();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}