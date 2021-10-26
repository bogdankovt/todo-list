using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using todo_list.Models;

namespace todo_list.Controllers
{   
    [Route("api/todo-list")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {   
        private static List<TodoItem> todoItems = new List<TodoItem>();

        public TodoItemController()
        {
        }

        [HttpGet("/todo-items")]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return todoItems;
        }

        [HttpGet("/todo-items/{id}")]
        public ActionResult<TodoItem> GetTodoItem(int id)
        {   

            return todoItems[id-1];
        }

        [HttpPost("/todo-items")]
        public ActionResult<TodoItem> PostTodoItem(TodoItem todoItem)
        {   
            todoItem.Id = todoItems.Count + 1;
            todoItems.Add(todoItem);
            return Created($"/todo-items/{todoItems.Count}",todoItem);
        }
        
        [HttpPatch("/todo-items/{id}")]
        public ActionResult PatchTodoItem(int id, [FromBody] JsonPatchDocument<TodoItem> patchTodoItem)
        {   
            var editItem = todoItems[id];
            patchTodoItem.ApplyTo(editItem, ModelState);
            return Ok();
        }

        [HttpPut("/todo-items/{id}")]
        public IActionResult PutTodoItem(int id, TodoItem todoItem)
        {   
            todoItems[id-1] = todoItem;
            return Ok();
        }

        [HttpDelete("/todo-items/{id}")]
        public ActionResult<TodoItem> DeleteTodoItemById(int id)
        {   
            var removeItem = todoItems[id - 1];
            todoItems.RemoveAt(id - 1);
            return removeItem;             
        }
    }
}