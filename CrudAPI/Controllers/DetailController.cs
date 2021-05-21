using CrudAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly DetailService _detailListService;
        public DetailController(DetailService detailListService)
        {
            _detailListService = detailListService;
        }

        [Route("AllCountries")]
        [HttpGet]
        public async Task<ActionResult> AllCountries()
        {
            var result = await _detailListService.GetAllCountries();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [Route("AllRoles")]
        [HttpGet]
        public async Task<ActionResult> AllRles()
        {
            var result = await _detailListService.GetAllRoles();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        
        [Route("AllSectors")]
        [HttpGet]
        public async Task<ActionResult> AllSectors()
        {
            var result = await _detailListService.GetAllSectors();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
