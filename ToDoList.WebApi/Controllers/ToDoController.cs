using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.DTO.ToDo;
using ToDoList.BLL.Services.Interfaces;


namespace ToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
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
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoCreateDTO toDoCreateDto)
        {
            var response = await _toDoService.AddAsync(toDoCreateDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ToDoUpdateDTO toDoUpdateDto)
        {
            if (id != toDoUpdateDto.Id)
            {
                return BadRequest();
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
}
