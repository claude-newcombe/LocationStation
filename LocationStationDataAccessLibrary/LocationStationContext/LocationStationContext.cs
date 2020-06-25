using LocationStationDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStationDataAccessLibrary.LocationStationContext
{
    public class LocationStationContext : DbContext
    {
        public LocationStationContext(DbContextOptions options) : base(options) { }
        public DbSet<MusicItem> MusicItems { get; set; }
    }
}
