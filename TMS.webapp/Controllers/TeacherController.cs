using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.webapp.DatabaseContext;
using TMS.webapp.Models;

namespace TMS.webapp.Controllers
{
    public class TeacherController : Controller
    {
       
        private readonly ApplicationDbContext _dbContext;
        public TeacherController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


       //index show//
        public async Task <IActionResult> Index()
        {
            var data = await _dbContext.Set<Teacher>().AsNoTracking().ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult>CreateOrEdit(int Id)
        {
            if(Id== 0)
            {
                return View(new Teacher());
            }
            else
            {
                var data = await _dbContext.Set<Teacher>().FindAsync(Id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult>CreateOrEDit(int Id, Teacher teacher)
        {
            if (Id == 0)
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.Set<Teacher>().AddAsync(teacher);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            //edit
            else
            {
                _dbContext.Set<Teacher>().Update(teacher);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(teacher);
        }
        //delete
        public async Task<IActionResult>Delete(int Id)
        {
            if (Id != 0) {
                var data = await _dbContext.Set<Teacher>().FindAsync(Id);
                if(data is not null)
                {
                    _dbContext.Set<Teacher>().Remove(data);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        //Details
        public async Task<IActionResult>Details(int Id)
        {
            var data = await _dbContext.Set<Teacher>().FindAsync(Id);
            return View(data);
        }
    }
}
