﻿using Microsoft.AspNetCore.Authorization;
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
    public class StoredPlateController : ControllerBase
    {
        private readonly IService<StoredPlateViewModel, StoredPlate> storedPlateService;

        public StoredPlateController(IService<StoredPlateViewModel, StoredPlate> service)
        {
            this.storedPlateService = service;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<IEnumerable<StoredPlateViewModel>> GetStoredPlates()
        {
            var storedPlates = this.storedPlateService.GetAll();

            return storedPlates.ToList();
        }

        [HttpGet]
        [Route("get/{plate}")]
        public ActionResult<StoredPlateViewModel> GetStoredPlate(string plate)
        {
            var storedPlate = this.storedPlateService.Get(p => p.Plate == plate).FirstOrDefault();

            return storedPlate;
        }

        [HttpPost]
        [Authorize(Policy = "ManagePlates")]
        [Route("add")]
        public void AddStoredPlate(StoredPlateViewModel plate)
        {
            storedPlateService.Insert(plate);
        }

        [HttpDelete]
        [Authorize(Policy = "ManagePlates")]
        [Route("delete")]
        public void DeleteStoredPlate(StoredPlateViewModel plate)
        {
            storedPlateService.Delete(plate);
        }

        [HttpDelete]
        [Authorize(Policy = "ManagePlates")]
        [Route("delete/{id:int}")]
        public void DeleteStoredPlate(int id)
        {
            storedPlateService.Delete(id);
        }

        [HttpPost]
        [Authorize(Policy = "ManagePlates")]
        [Route("update")]
        public void UpdateStoredPlate(StoredPlateViewModel plate)
        {
            storedPlateService.Update(plate);
        }
    }
}
