using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocationStationWeb.Models
{
    public class LocationModel
    {
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }
}
