using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp_BackendAPI.Data;
using TodoApp_BackendAPI.Models;

namespace TodoApp_BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }


        // Get All Todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            try
            {
                var todos = await _context.Todos.ToListAsync();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Get a Single Todo
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            try
            {
                var todo = await _context.Todos.FirstOrDefaultAsync(e => e.TodoId == id);

                if (todo != null)
                {
                    return Ok(todo);
                }
                return NotFound("Todo is not available");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // Add a New Todo
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            if(todo != null)
            {
                _context.Todos.Add(todo);

                try
                {
                    await _context.SaveChangesAsync();

                    // to send back the new todo
                    return CreatedAtAction(nameof(GetTodos), new { id = todo.TodoId }, todo);

                    // to send back the entire todo list. Use with 'Task<ActionResult<List<Todo>>>'
                    //return Ok(await _context.Todos.ToListAsync());
                }
                catch (Exception ex) 
                {
                    //Console.WriteLine(ex);
                    return StatusCode(500,  $"An unexpected error occurred : {ex.Message}");                
                }

            }
            return BadRequest("Object instance not set");
            
        }


        // Update a Todo
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo todo)
        {
            if (id != todo.TodoId)
            {
                return BadRequest("Invalid todo data"); // To avoid changing the ID.
            }

            if (todo != null)
            {
                //_context.Entry(todo).State = EntityState.Modified;

                try
                {
                    var existingTodo = await _context.Todos.FindAsync(id);

                    if (existingTodo == null)
                    {
                        return NotFound("Todo does not exist");
                    }

                    existingTodo.Title = todo.Title;
                    existingTodo.Description = todo.Description;
                    existingTodo.IsCompleted = todo.IsCompleted;

                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Conflict("Concurrency conflict: The resource has been modified by another user. Please fetch the latest version and try again.");
                }
                catch (DbUpdateException)
                {
                    return BadRequest("Error updating the resource. Check your data and try again.");
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex);
                    return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
                }
                
            }

            return BadRequest("Invalid request");
        }


        // Delete a Todo
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                var todo = await _context.Todos.FindAsync(id);

                if (todo == null)
                {
                    return NotFound("Todo does not exist");
                }

                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                return StatusCode(500, $"An unexpected error occurred : {ex.Message}");
            }
            
        }
    }
}
