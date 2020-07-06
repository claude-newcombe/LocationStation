using LocationStationDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationStationDataAccessLibrary.DataAccess;
using SQLitePCL;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.FileProviders.Physical;

namespace LocationStationAPI.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly LocationStationContext _context;

        public MusicRepository(LocationStationContext context)
        {
            _context = context;
        }

        public IList<MusicItem> GetMusicItems()
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

        public MusicItem GetClosestMusicItem(float Latitude, float Longitude)
        {
            var musicItemslist = GetMusicItems();
            var musicDistances = CreateDistanceDictionary(musicItemslist, Latitude, Longitude);
            var sortedDistances = SortByDistance(musicDistances);
            var key = sortedDistances.FirstOrDefault().Key;
            var closestMusicItem = musicItemslist.FirstOrDefault(x => x.Id == key);

            return closestMusicItem;
        }

        public IDictionary<int, double> CreateDistanceDictionary(IList<MusicItem> items, float latitude, float longitude)
        {
            IDictionary<int, double> DistanceDictionary = new Dictionary<int, double>();
            foreach(var item in items)
            {
                var itemDistance = PythagorianDistance(latitude, longitude, item.Latitude, item.Longitude);
                DistanceDictionary.Add(item.Id, itemDistance);
            }
            return DistanceDictionary;
        }

        public double PythagorianDistance(float lat1, float long1, float lat2, float long2)
        {
            var lattitudeDifference = lat1 - lat2;
            var longitudeDifference = long1 - long2;
            var distance = Math.Sqrt(Math.Pow(lattitudeDifference, 2) + Math.Pow(longitudeDifference, 2));
            return distance;
        }

        public IDictionary<int, double> SortByDistance(IDictionary<int, double> unsortedDistances)
        {
            IDictionary<int, double> sortedDistances = new Dictionary<int, double>();
            foreach (KeyValuePair<int, double> distance in unsortedDistances.OrderBy(key => key.Value))
            {
                sortedDistances.Add(distance);
            }
            return sortedDistances;
        }
    }
}
