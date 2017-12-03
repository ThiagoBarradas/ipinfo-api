using IpInfo.Api.Managers;
using IpInfo.Api.Models.Request;
using Nancy.ModelBinding;
using Nancy.Validation;

namespace IpInfo.Api.Controller
{
    public class InfoController : BaseController
    {
        private IIpInfoManager IpInfoManager { get; set; }

        public InfoController(IIpInfoManager ipInfoManager) 
        {
            this.IpInfoManager = ipInfoManager;

            this.Get("ip/{ip}", args => this.GetIpInfo());
        }

        public object GetIpInfo()
        {
            var request = this.Bind<GetIpInfoRequest>();
            
            var validation = this.Validate(request);
            if (validation.IsValid == false)
            {
                return this.CreateBadRequestResponse(validation);
            }

            var response = this.IpInfoManager.GetIpInfo(request);

            return this.CreateResponse(response);
        }
    }
}
