using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LocationStationDataAccessLibrary.Models
{
    public class MusicItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string SongName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Artist { get; set; }

        [Required]
        [MaxLength(200)]
        public string LocationName { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        public float Latitude{ get; set; }

        [Required]
        [MaxLength(500)]
        public string Metadata { get; set; }

        [Required]
        [MaxLength(100)]
        public string YouTubeLink { get; set; }

    }
}
