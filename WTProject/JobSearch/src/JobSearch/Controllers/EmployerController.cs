using JobSearch.Data;
using JobSearch.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobSearch.Controllers
{
    public class Employer : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public Employer(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var model = new EmployerViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                CompanyName = user.CompanyName,
                Address = user.Address,
                CompanyDescription = user.CompanyDescription,
                Phone = user.Phone
            };
            return View(model);
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();

            if (user == null)
            {
                return NotFound();
            }

            var model = new EmployerViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                CompanyName = user.CompanyName,
                Address = user.Address,
                CompanyDescription = user.CompanyDescription,
                Phone = user.Phone
            };
            return View(model);

           }

           [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<ActionResult> Edit(EmployerViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                // var user = await _users.FindByIdAsync(editUser.Id);
                var user = await _userManager.FindByIdAsync(editUser.Id.ToString());

                if (user == null)
                {
                    return NotFound();
                }

                user.Id = editUser.Id;
                user.UserName = editUser.UserName;
                user.Email = editUser.Email;
                user.CompanyName = editUser.CompanyName;
                user.Address = editUser.Address;
                user.CompanyDescription = editUser.CompanyDescription;
                user.Phone = editUser.Phone;


                //var result = await _users.UpdateAsync(user);
                var result = await _userManager.UpdateAsync(user);


                if (!result.Succeeded)
                {
                    ModelState.AddModelError("","result.Errors.First()");
                    return View();
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}