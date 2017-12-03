using FluentValidation;
using IpInfo.Api.Models.Request;
using IpInfo.Api.Utilities;
using System.Text.RegularExpressions;

namespace IpInfo.Api.Validators
{
    public class GetIpInfoValidator : AbstractValidator<GetIpInfoRequest>
    {
        public GetIpInfoValidator()
        {
            RuleFor(obj => obj.Ip).NotEmpty().Must(IpValidator);
        }

        private static bool IpValidator(string ip)
        {
            var match = Regex.Match(ip, RegexUtility.IP, RegexOptions.IgnoreCase);
            return match.Success;
        }
    }
}
