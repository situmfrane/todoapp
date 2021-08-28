using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Model;

namespace ToDoList.Pages
{
    public class Create : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Create(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [BindProperty]
        public Model.ToDoList ToDo { get; set; }
        
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.ToDoList.AddAsync(ToDo);
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