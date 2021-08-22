using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using karachun_geo.BI.Interfaces;
using karachun_geo.Data.Base;

namespace karachun_geo.API.Hubs
{
    public class GeolocationHub : Hub
    {
        private readonly IGeolocation _geolocation;
        private static Dictionary<string, Coordinates> UsersOnMap = new Dictionary<string, Coordinates>();

        public GeolocationHub(IGeolocation geolocation)
        {
            _geolocation = geolocation;
        }

        public async Task OnUserLocation(string lng, string lat)
        {
            UsersOnMap[Context.ConnectionId].Lat = Parse(lat);
            UsersOnMap[Context.ConnectionId].Lng = Parse(lng);

            var idNearbyObject = await _geolocation.GetObjectsNearby(new Coordinates()
            {
                Lat = double.Parse(lat),
                Lng = double.Parse(lng)
            });

            if (idNearbyObject > 0)
                await Clients.Caller.SendAsync("Audioguide", idNearbyObject);

            await Clients.Caller.SendAsync("FamalyLocations", UsersOnMap.Where(x => x.Key != Context.ConnectionId).Select(x => x.Value).ToArray());
        }

        public async Task JoinFamaly(string connectionId, string group)
        {
            await Groups.AddToGroupAsync(connectionId, group);
            await Clients.Group(group).SendAsync("Message", "Пользователь из вашей семьи зашел в приложение!");
        }

        public override async Task OnConnectedAsync()
        {
            await JoinFamaly(Context.ConnectionId, "Default");

            await base.OnConnectedAsync();
        }

        private double Parse(string d) => double.Parse(d);
    }
}
