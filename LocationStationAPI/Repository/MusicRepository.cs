using LocationStationDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationStationDataAccessLibrary.DataAccess;
using SQLitePCL;
using System.Security.Cryptography.X509Certificates;

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

        public MusicItem GetMusicItem(int id)
        {
            return _context.MusicItems.FirstOrDefault(x => x.Id == id);
        }

        public MusicItem AddMusicItem(MusicItem musicItem)
        {
            _context.MusicItems.Add(musicItem);
            _context.SaveChanges();
            return musicItem;
        }

        public MusicItem DeleteMusicItem(int id)
        {
            var musicItem = _context.MusicItems.FirstOrDefault(x => x.Id ==id);
            _context.MusicItems.Remove(musicItem);
            _context.SaveChanges();
            return musicItem;
        }

    }
}
