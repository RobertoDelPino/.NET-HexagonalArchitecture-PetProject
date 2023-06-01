using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetProject_4.Application.Services;
using PetProject_4.Domain.Models;
using PetProject_4.Infrastructure.Data.Models;
using PetProject_4.Infrastructure.Data.Repositories;

namespace PetProject_2.Controllers
{
    public class UserProjectsController : Controller
    {
        UserProjectService CreateService()
        {
            UsersContext database = new UsersContext();
            UserProjectRepository repository = new UserProjectRepository(database);
            UserProjectService service = new UserProjectService(repository);
            return service;
        }


        // GET: UserProjects
        public IActionResult Index()
        {
            var user = User?.Identity?.Name;
            if(user != null)
            {
                UserProjectService service = CreateService();
                
                return View(service.GetAllBy(user));
            }

            return Redirect("Identity/Account/Login");
            
        }

        // GET: UserProjects/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            UserProjectService service = CreateService();

            UserProject userProject = service.GetById(id.Value);
            if (userProject == null)
            {
                return NotFound();
            }

            return View(userProject);
        }

        // GET: UserProjects/Create
        /*public IActionResult Create()
        {
            ViewData["UserId"] = getAuthenticatedUserId();
            return View();
        }

        // POST: UserProjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,UserId,Name,Description,repository,page,image,date")] UserProject userProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = getAuthenticatedUserId();
            return View(userProject);
        }

        // GET: UserProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserProjects == null)
            {
                return NotFound();
            }

            var userProject = await _context.UserProjects.FindAsync(id);
            if (userProject == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = getAuthenticatedUserId();
            return View(userProject);
        }

        // POST: UserProjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,UserId,Name,Description,repository,page,image,date")] UserProject userProject)
        {
            if (id != userProject.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProjectExists(userProject.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = getAuthenticatedUserId();
            return View(userProject);
        }*/

        // GET: UserProjects/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserProjectService service = CreateService();

            UserProject userProject = service.GetById(id.Value);
            
            if (userProject == null)
            {
                return NotFound();
            }

            return View(userProject);
        }

        // POST: UserProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                UserProjectService service = CreateService();
                service.Delete(id);
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
            
            return RedirectToAction(nameof(Index));
        }

        /*private bool UserProjectExists(int id)
        {
          return (_context.UserProjects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }


        private string getAuthenticatedUserId()
        {
            var userName = User?.Identity?.Name;
            var user = _context.AspNetUsers.First(x => x.UserName == userName);
            return user.Id;
        }*/

    }
}
