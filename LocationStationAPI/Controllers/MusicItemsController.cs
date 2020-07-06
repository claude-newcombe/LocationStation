using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using LocationStationAPI.Repository;
using LocationStationDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicItemsController : ControllerBase
    {
        private readonly IMusicRepository _repository;

        public MusicItemsController(IMusicRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MusicItem>> GetMusicItems()
        {
            var MusicItems = _repository.GetMusicItems();
            return Ok(MusicItems);
        }

        [HttpGet("{id}")]
        public ActionResult<MusicItem> GetMusicItem(int id)
        {
            var MusicItem = _repository.GetMusicItem(id);
            return Ok(MusicItem); //safety net for if id doesn't return anything
        }

        [HttpGet("{longitude}/{latitude}")]
        public ActionResult<MusicItem> GetNearestMusicItem(float longitude, float latitude)
        {
            var nearestMusicItem = _repository.GetClosestMusicItem(longitude, latitude);
            return nearestMusicItem;
        }

        [HttpPost]
        public ActionResult<MusicItem> PostMusicItem(MusicItem musicItem)
        {
            var addedItem = _repository.AddMusicItem(musicItem);
            return Ok(addedItem);
        }

        [HttpDelete("{id}")]
        public ActionResult<MusicItem> DeleteMusicItem(int id)
        {
            var deletedItem = _repository.DeleteMusicItem(id);
            return Ok(deletedItem);
        }
    }
}
