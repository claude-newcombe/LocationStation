using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LocationStationDataAccessLibrary.Models;
using LocationStationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Collections;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using Microsoft.CodeAnalysis.Options;

namespace LocationStationWeb.Pages
{
    public class PlayModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public PlayModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        [BindProperty(SupportsGet = true)]
        public LocationModel Location { get; set; }
        public string ResponseString { get; set; }
        public MusicItem MusicItem { get; set; }
        public async Task OnGet()
        {
            var requestString = "https://localhost:44335/api/MusicItems/" + Location.Longitude + "/" + Location.Latitude;
            var request = new HttpRequestMessage(HttpMethod.Get, requestString);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                using var responseStream = await response.Content.ReadAsStreamAsync();
                MusicItem = await JsonSerializer.DeserializeAsync<MusicItem>(responseStream, options);
            }
            else
            {
                ResponseString = "Failure";
            }
        }
    }
}