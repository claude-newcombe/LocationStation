using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationStationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LocationStationWeb.Pages
{
    public class PlayModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public LocationModel Location { get; set; }
        public void OnGet()
        {

        }
    }
}