using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using karachun_geo.Data.Base;

namespace karachun_geo.BI.Interfaces
{
    public interface IGeolocation
    {
        Task<int> GetObjectsNearby(Coordinates coordinates);
    }
}
