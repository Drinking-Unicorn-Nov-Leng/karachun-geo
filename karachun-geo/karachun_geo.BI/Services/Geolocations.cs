using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using karachun_geo.BI.Interfaces;
using karachun_geo.Data.Base;
using karachun_geo.BI.Options;

namespace karachun_geo.BI.Services
{
    public class Geolocations : IGeolocation
    {
        private readonly IDataSend _dataSend;
        private readonly MapConfig _config;

        public Geolocations(IDataSend dataSend, MapConfig config)
        {
            _dataSend = dataSend;
            _config = config;
        }

        public async Task<int> GetObjectsNearby(Coordinates coordinates)
        {
            return await _dataSend.Get<int>(_config.Url + $"?Lat={coordinates.Lat.ToString("G", CultureInfo.InvariantCulture)}&Lng={coordinates.Lng.ToString("G", CultureInfo.InvariantCulture)}");
        }
    }
}
