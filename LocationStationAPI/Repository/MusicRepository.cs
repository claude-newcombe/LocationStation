using LocationStationDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationStationDataAccessLibrary.DataAccess;
using SQLitePCL;

namespace LocationStationAPI.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly LocationStationContext _context;

        public MusicRepository(LocationStationContext context)
        {
            _context = context;
        }
        public IEnumerable<MusicItem> GetMusicItems()
        {
            return _context.MusicItems.ToList();
        }
    }
}
