using System.Globalization;
using System.Linq;

namespace IpInfo.Api.Models
{
    public class IpInfoServiceData
    {
        public IpInfoServiceData()
        {
            this.City = "Unknow";
            this.Region = "Unknow";
            this.Country = "Unknow";
        }

        public bool IsEmpty()
        {
            return this.City == "Unknow" &&
                   this.Region == "Unknow" &&
                   this.Country == "Unknow" &&
                   this.GetLatitude() == 0 &&
                   this.GetLongitude() == 0;
        }

        public string Ip { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string Loc { get; set; }

        public double GetLatitude()
        {
            if (string.IsNullOrWhiteSpace(this.Loc) == true) return 0;

            var coord = this.Loc.Split(',');
            return (coord.Count() == 2) ? double.Parse(coord[0], CultureInfo.InvariantCulture) : 0;
        }

        public double GetLongitude()
        {
            if (string.IsNullOrWhiteSpace(this.Loc) == true) return 0;

            var coord = this.Loc.Split(',');
            return (coord.Count() == 2) ? double.Parse(coord[1], CultureInfo.InvariantCulture) : 0;
        }
    }
}
