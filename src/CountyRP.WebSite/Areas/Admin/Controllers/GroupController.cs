﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class GroupController : ControllerBase
    {
        private IGroupAdapter _groupAdapter;

        public GroupController(IGroupAdapter groupAdapter)
        {
            _groupAdapter = groupAdapter;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Group group)
        {
            try
            {
                group = await _groupAdapter.Create(group);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(group);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Group group;

            try
            {
                group = await _groupAdapter.GetById(id);
            }
            catch (AdapterException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(group);
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> FilterBy(int page, string id, string name)
        {
            FilteredModels<Group> groups;

            try
            {
                groups = await _groupAdapter.FilterBy(page, 20, id, name);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(groups);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody]Group group)
        {
            try
            {
                group = await _groupAdapter.Edit(id, group);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(ex.Message);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(ex.Message);
            }

            return Ok(group);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _groupAdapter.Delete(id);
            }
            catch (AdapterException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }
    }
}
