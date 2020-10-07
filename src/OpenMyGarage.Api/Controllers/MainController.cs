using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenMyGarage.Domain.Service;
using OpenMyGarage.Domain.ViewModel;
using OpenMyGarage.Entity.Entity;
using System.Linq;

namespace OpenMyGarage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MainController : ControllerBase
    {
        private readonly IService<EntryLogViewModel, EntryLog> entryLogService;
        private readonly IService<StoredPlateViewModel, StoredPlate> storedPlateService;

        public MainController(IService<EntryLogViewModel, EntryLog> entryLogService, IService<StoredPlateViewModel, StoredPlate> storedPlateService)
        {
            this.entryLogService = entryLogService;
            this.storedPlateService = storedPlateService;
        }

        [HttpPost]
        [Authorize(Roles = "RaspberryPi")]
        [Route("entry")]
        public void Entry([FromBody] EntryLogViewModel entryLog)
        {
            LogEntry(entryLog);
            var storedPlate = storedPlateService.Get(s => s.Plate == entryLog.Plate).FirstOrDefault();
            if (storedPlate != null && storedPlate.AutoOpen)
                OpenGate();
            else
                ; //firebase
        }

        [HttpGet]
        [Authorize(Policy = "OpenGate")]
        [Route("gate")]
        public void OpenGate() { }

        private void LogEntry(EntryLogViewModel entryLog)
        {
            entryLogService.Insert(entryLog);
        }
    }
}
