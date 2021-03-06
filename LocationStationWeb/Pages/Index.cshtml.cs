﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationStationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LocationStationWeb.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public LocationModel Location { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            return RedirectToPage("Play", Location);
        }
    }
}
