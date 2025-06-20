
using Microsoft.AspNetCore.Mvc;
using ToDoWebAppList.Data;
using ToDoWebAppList.Models;

namespace ToDoWebAppList.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        // Inject AppDbContext (to access database)
        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Todo/Index
        public IActionResult Index()
        {
            // Load all Todo items from database
            var todos = _context.TodoItems.ToList();

            // Pass to View
            return View(todos);
        }

        // GET: /Todo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItem item)
        {
            if (ModelState.IsValid)
            {
                _context.TodoItems.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

    }
}


