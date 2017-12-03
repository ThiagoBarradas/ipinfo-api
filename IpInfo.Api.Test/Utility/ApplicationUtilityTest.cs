using IpInfo.Api.Utilities;
using Xunit;

namespace IpInfo.Api.Test.Utility
{
    public class ApplicationUtilityTest
    {
        [Fact]
        public void Should_Return_A_String_For_Application_Title()
        {
            // act
            var result = ApplicationUtility.GetApplicationTitle();

            // assert
            Assert.True(string.IsNullOrWhiteSpace(result) == false);
        }
    }
}
