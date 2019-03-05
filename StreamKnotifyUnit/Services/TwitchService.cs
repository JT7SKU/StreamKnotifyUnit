using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using StreamKnotifyUnit.Shared;
namespace StreamKnotifyUnit.Services
{
    public class TwitchService
    {
        private HttpClient Http = new HttpClient();
        public async Task<List<Subscriber>> GetSubscribersAsync()
        { 
            var subscribers = await Http.GetJsonAsync<List<Subscriber>>("");
            return subscribers;
        }
        public async Task<List<Follower>> GetFollowersAsync()
        {
            var followers = await Http.GetJsonAsync<List<Follower>>("");
            return followers;
        }
        public async Task<List<Cheer>> GetCheerersAsync()
        {
            var cheerers = await Http.GetJsonAsync<List<Cheer>>("");
            return cheerers;
        }
        public async Task<List<Tip>> GetTipperssAsync()
        {
            var tippers = await Http.GetJsonAsync<List<Tip>>("");
            return tippers;
        }
    }
}
