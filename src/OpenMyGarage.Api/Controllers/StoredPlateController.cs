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
    public class StoredPlateController : ControllerBase
    {
        private readonly IService<StoredPlateViewModel, StoredPlate> storedPlateService;

        public StoredPlateController(IService<StoredPlateViewModel, StoredPlate> service)
        {
            this.storedPlateService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StoredPlateViewModel>> GetStoredPlates()
        {
            var storedPlates = this.storedPlateService.GetAll();

            return storedPlates.ToList();
        }

        [HttpPost]
        [Authorize(Policy = "ManagePlates")]
        public void AddStoredPlate(StoredPlateViewModel plate)
        {
            storedPlateService.Insert(plate);
        }

        [HttpDelete]
        [Authorize(Policy = "ManagePlates")]
        public void DeleteStoredPlate(StoredPlateViewModel plate)
        {
            storedPlateService.Delete(plate);
        }

        [HttpPost]
        [Authorize(Policy = "ManagePlates")]
        public void UpdateStoredPlate(StoredPlateViewModel plate)
        {
            storedPlateService.Update(plate);
        }
    }
}
