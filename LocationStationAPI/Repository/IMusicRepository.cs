using LocationStationDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationStationAPI.Repository
{
    public interface IMusicRepository
    {
        IList<MusicItem> GetMusicItems();

        MusicItem GetMusicItem(int id);

        MusicItem AddMusicItem(MusicItem musicItem);

        MusicItem DeleteMusicItem(int id);

        MusicItem GetClosestMusicItem(float Latitude, float Longitude);

    }
}