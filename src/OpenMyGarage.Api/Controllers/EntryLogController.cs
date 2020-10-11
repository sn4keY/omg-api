using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenMyGarage.Domain.Service;
using OpenMyGarage.Domain.ViewModel;
using OpenMyGarage.Entity.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OpenMyGarage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EntryLogController : ControllerBase
    {
        private readonly IService<EntryLogViewModel, EntryLog> entryLogService;

        public EntryLogController(IService<EntryLogViewModel, EntryLog> service)
        {
            this.entryLogService = service;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<EntryLogViewModel>> GetEntryLogs()
        {
            var entryLogs = entryLogService.GetAll();

            return entryLogs.ToList();
        }

        [HttpGet]
        [Route("picture/{id:int}")]
        public ActionResult GetPicture(int id)
        {
            var viewModel = entryLogService.GetById(id);
            var image = System.IO.File.OpenRead($"/Images/{viewModel.EntryTime}_{viewModel.Plate}.jpg");

            return File(image, "image/jpeg");
        }
    }
}
