using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _writeContext;
        private readonly TodoDbReadContext _readContext;

        public TodoController(TodoDbContext writeContext, TodoDbReadContext readContext)
        {
            _writeContext = writeContext;
            _readContext = readContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            return await _readContext.Todos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await _readContext.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            _writeContext.Todos.Add(todo);
            await _writeContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }
            _writeContext.Entry(todo).State = EntityState.Modified;
            await _writeContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _writeContext.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            _writeContext.Todos.Remove(todo);
            await _writeContext.SaveChangesAsync();
            return NoContent();
        }
    }
}