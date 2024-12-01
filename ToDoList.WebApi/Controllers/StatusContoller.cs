﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.DTO.Status;
using ToDoList.BLL.Services.Interfaces;

namespace ToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusContoller : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IStatusService _statusService;

        public StatusContoller(IStatusService statusService, ILogger logger)
        {
            _statusService = statusService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _statusService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _statusService.GetByIdAsync(id);
            if (response == null)
            {
                _logger.LogWarning("Status with ID {Id} not found.", id);
                return NotFound($"Status with ID {id} not found.");
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StatusCreateDTO statusCreateDTO)
        {
            var response = await _statusService.AddAsync(statusCreateDTO);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StatusUpdateDTO statusUpdateDTO)
        {
            if (id != statusUpdateDTO.Id)
            {
                _logger.LogWarning("ID mismatch in update request. ID in URL: {UrlId}, ID in DTO: {DtoId}.", id, statusUpdateDTO.Id);
                return BadRequest("ID mismatch.");
            }

            var response = await _statusService.UpdateAsync(statusUpdateDTO);
            if (response == null)
            {
                _logger.LogWarning("Status with ID {Id} not found.", id);
                return NotFound($"Status with ID {id} not found.");
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _statusService.DeleteAsync(id);
            return NoContent();
        }
    }
}