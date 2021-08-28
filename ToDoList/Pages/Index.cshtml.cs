using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDoList.Model;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Model.ToDoList> ToDo { get; set; } 

        public async Task OnGet()
        {
            ToDo = await _db.ToDoList.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            
            var task = await _db.ToDoList.FindAsync(id);
            
            if (task == null)
            {
                return NotFound();
            }
            
            _db.ToDoList.Remove(task);
            await _db.SaveChangesAsync();
        
            return RedirectToPage("Index");
        
        }
        
    }
}