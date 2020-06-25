using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStationDataAccessLibrary.Models
{
    public class MusicItem
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public string Artist { get; set; }
        public string LocationName { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Metadata { get; set; }
        public string YouTubeLink { get; set; }

    }
}
