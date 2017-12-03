using IpInfo.Api.Models.Request;
using IpInfo.Api.Models.Response;

namespace IpInfo.Api.Managers
{
    public interface IIpInfoManager
    {
        BaseResponse<GetIpInfoResponse> GetIpInfo(GetIpInfoRequest request);
    }
}
