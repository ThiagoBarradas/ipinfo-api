namespace IpInfo.Api.Models.Response
{
    public class GetIpInfoResponse
    {
        public GetIpInfoResponse() { }

        public GetIpInfoResponse(IpInfoServiceData serviceData)
        {
            this.Latitude = serviceData.GetLatitude();
            this.Longitude = serviceData.GetLongitude();
            this.City = serviceData.City;
            this.State = serviceData.Region;
            this.Country = serviceData.Country;
        }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
