using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CrudAPI.Domain;
using CrudAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers
{
    
    [Route("api/[controller]")]
    [Controller]
    public class SuppliersController : Controller
    {
        
        
        private readonly SuppliersService _todoListService;

        
        public SuppliersController(SuppliersService todoListService)
        {
            _todoListService = todoListService;
        }
        
        [Route("CreateSuppliers")]
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]Suppliers todoList)
        {
            var result = await _todoListService.Insert(todoList);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Route("GetAllSuppliers")]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _todoListService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [Route("SuppliersById/id")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _todoListService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [Route("UpdateSuppliersById")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody]Suppliers todoList)
        {
            var result = await _todoListService.Update(todoList);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [Route("DeleteSuppliers/id")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _todoListService.Remove(id);
            return Ok();
        }
        
    }
}