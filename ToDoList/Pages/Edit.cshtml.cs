using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Model;

namespace ToDoList.Pages
{
    public class Edit : PageModel
    {
        private ApplicationDbContext _db;

        public Edit(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Model.ToDoList ToDo { get; set; }
        
        public async Task OnGet(int id)
        {
            ToDo = await _db.ToDoList.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var TaskFromDb = await _db.ToDoList.FindAsync(ToDo.Id);
                TaskFromDb.TaskName = ToDo.TaskName;
                TaskFromDb.Assignee = ToDo.Assignee;
                TaskFromDb.IsDone = ToDo.IsDone;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}