using IpInfo.Api.Models;
using IpInfo.Api.Models.Response;
using IpInfo.Api.Utilities.Interface;
using System.Net;
using IpInfo.Api.Models.Request;
using RestSharp;

namespace IpInfo.Api.Managers
{
    public class IpInfoManager : IIpInfoManager
    {
        private IConfigurationUtility ConfigurationUtility { get; set; }

        public IpInfoManager(IConfigurationUtility configurationUtility)
        {
            this.ConfigurationUtility = configurationUtility;
        }

        public BaseResponse<GetIpInfoResponse> GetIpInfo(GetIpInfoRequest request)
        {
            BaseResponse<GetIpInfoResponse> response = new BaseResponse<GetIpInfoResponse>();

            IRestClient restClient = new RestClient(this.ConfigurationUtility.IpInfoServiceUrl);
            restClient.Timeout = (this.ConfigurationUtility.IpInfoServiceTimeoutInSeconds * 1000);

            var restRequest = new RestRequest("{ip}/json", Method.GET);
            restRequest.AddUrlSegment("ip", request.Ip);
            restRequest.AddHeader("Accept", "application/json");

            var restResponse = restClient.Execute<IpInfoServiceData>(restRequest);

            if (restResponse.ErrorException != null)
            {
                throw restResponse.ErrorException;
            }

            if (restResponse.StatusCode != HttpStatusCode.OK || restResponse.Data.IsEmpty())
            {
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.SuccessBody = new GetIpInfoResponse(restResponse.Data);
            }

            return response;
        }
    }
}
