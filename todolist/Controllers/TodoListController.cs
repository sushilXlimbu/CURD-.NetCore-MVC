using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using todolist.Models;

namespace todolist.Controllers
{
    public class TodoListController : Controller
    {
        private readonly TodoDbContext _dbContext;

        public TodoListController(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<TodoList> TodoList = await _dbContext.Todolists.OrderByDescending(e => e.Date).ToListAsync();

            return View(TodoList);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ViewTodoList model)
        {
            ViewBag.selectedValue = model.selection;
            if (model.selection == "all")
            {
                List<TodoList> TodoList = await _dbContext.Todolists.OrderByDescending(e => e.Date).ToListAsync();
                return View(TodoList);
            }
            else if (model.selection == "selected")
            {
                List<TodoList> TodoList = await _dbContext.Todolists.OrderByDescending(e => e.Date).Where(i => i.IsCompleted == true).ToListAsync();
                return View(TodoList);

            }
            else
            {
                List<TodoList> TodoList = await _dbContext.Todolists.OrderByDescending(e => e.Date).Where(i => i.IsCompleted == false).ToListAsync();
                return View(TodoList);
            }
        }


        //[HttpGet]
        //public async Task<IActionResult> Completedtodo()
        //{
        //    List<TodoList> Completedlist = await _dbContext.Todolists.OrderByDescending(e => e.Date).Where(i => i.IsCompleted == true).ToListAsync();
        //    return View("Index", Completedlist);
        //}

        [HttpGet]
        public IActionResult AddTodo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTodo(AddTodoList list)
        {
            if (ModelState.IsValid)
            {
                TodoList todolist = new TodoList()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Title = list.Title,
                    Description = list.Description,

                };

                await _dbContext.Todolists.AddAsync(todolist);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(list);
            }


        }

        [HttpGet]
        public async Task<IActionResult> EditTodo(Guid Id)
        {
            var selectedtodo = await _dbContext.Todolists.FirstOrDefaultAsync(x => x.Id == Id);

            if (selectedtodo != null)
            {
                var edittodo = new EditTodoList
                {
                    Id = selectedtodo.Id,
                    Title = selectedtodo.Title,
                    Description = selectedtodo.Description,
                    IsCompleted = selectedtodo.IsCompleted

                };
                return View(edittodo);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<IActionResult> EditTodo(EditTodoList todo)
        {
            if (ModelState.IsValid)
            {
                var todolist = await _dbContext.Todolists.FindAsync(todo.Id);
                if (todolist != null)
                {
                    todolist.Title = todo.Title;
                    todolist.Description = todo.Description;
                    todolist.IsCompleted = todo.IsCompleted;

                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
            }
            return View(todo);

        }
        [HttpGet]
        public async Task<IActionResult> DeleteTodo(Guid Id)
        {
            TodoList? selectedtodo = await _dbContext.Todolists.FirstOrDefaultAsync(x => x.Id == Id);
            if (selectedtodo != null)
            {
                _dbContext.Todolists.Remove(selectedtodo);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Status(Guid Id)
        {
            var selectedtodo = _dbContext.Todolists.FirstOrDefault(x => x.Id == Id);

            selectedtodo.IsCompleted = (selectedtodo.IsCompleted == true) ? false : true;

            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
