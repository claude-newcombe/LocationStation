using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
