using IpInfo.Api.Utilities;
using System.Text.RegularExpressions;
using Xunit;

namespace IpInfo.Api.Test.Utility
{
    public class RegexUtilityTest
    {
        [Fact]
        public void Should_Return_A_Valid_IP()
        {
            // arrange
            var ip = "100.125.200.100";

            // act
            var match = Regex.Match(ip, RegexUtility.IP, RegexOptions.IgnoreCase);

            // assert
            Assert.True(match.Success);
        }

        [Fact]
        public void Should_Return_A_Invalid_IP_By_Range()
        {
            // arrange
            var ip = "100.256.200.100";

            // act
            var match = Regex.Match(ip, RegexUtility.IP, RegexOptions.IgnoreCase);

            // assert
            Assert.True(match.Success == false);
        }

        [Fact]
        public void Should_Return_A_Invalid_IP_By_Some_String()
        {
            // arrange
            var ip = "some text";

            // act
            var match = Regex.Match(ip, RegexUtility.IP, RegexOptions.IgnoreCase);

            // assert
            Assert.True(match.Success == false);
        }
    }
}
