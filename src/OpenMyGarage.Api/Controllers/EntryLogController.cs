using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenMyGarage.Domain.Service;
using OpenMyGarage.Domain.ViewModel;
using OpenMyGarage.Entity.Entity;

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
    }
}
