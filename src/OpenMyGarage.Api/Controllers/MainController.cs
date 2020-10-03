﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    public class MainController : ControllerBase
    {
        private readonly IService<EntryLogViewModel, EntryLog> entryLogService;
        private readonly IService<StoredPlateViewModel, StoredPlate> storedPlateService;

        public MainController(IService<EntryLogViewModel, EntryLog> entryLogService, IService<StoredPlateViewModel, StoredPlate> storedPlateService)
        {
            this.entryLogService = entryLogService;
            this.storedPlateService = storedPlateService;
        }

        [HttpGet]
        [Authorize(Roles = "RaspberryPi")]
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
        public void OpenGate() { }

        private void LogEntry(EntryLogViewModel entryLog)
        {
            entryLogService.Insert(entryLog);
        }
    }
}