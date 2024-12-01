using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.DTO.ToDo;
using ToDoList.BLL.Services.Interfaces;


namespace ToDoList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _toDoService;
    private readonly ILogger<ToDoController> _logger;

    public ToDoController(IToDoService toDoService, ILogger<ToDoController> logger)
    {
        _toDoService = toDoService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _toDoService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _toDoService.GetByIdAsync(id);
        if (response == null)
        {
            _logger.LogWarning("Status with ID {Id} not found.", id);
            return NotFound($"Status with ID {id} not found.");
        }
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ToDoCreateDTO toDoCreateDto)
    {
        var response = await _toDoService.AddAsync(toDoCreateDto);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ToDoUpdateDTO toDoUpdateDto)
    {
        if (id != toDoUpdateDto.Id)
        {
            _logger.LogWarning("ID mismatch in update request. ID in Request Object: {Request Object}, ID in DTO: {DtoId}.", id, toDoUpdateDto.Id);
            return BadRequest("ID mismatch.");
        }

        var response = await _toDoService.UpdateAsync(toDoUpdateDto);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _toDoService.DeleteAsync(id);
        return NoContent();
    }
}