using JobSearch.Data;
using JobSearch.Entities;
using JobSearch.Models;
using JobSearch.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace JobSearch.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobInfo _jobInfo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public JobController(IJobInfo jobInfo,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _jobInfo = jobInfo;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var user = GetCurrentUserAsync();
            if(user == null)
                return RedirectToAction("Index", "Account");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobViewModel model)
        {
            var user = await GetCurrentUserAsync();
            if (ModelState.IsValid)
            {
                var job = new Job {
                    Title = model.Title,
                    JobType = model.JobType,
                    Salary = model.Salary,
                    Description = model.Description,
                    NoOfVacancies = model.NoOfVacancies,
                    PublishedDate = DateTime.Today,
                    Deadline = model.Deadline,
                    UserID = user.Id
                };

                _context.JobVacancy.Add(job);
                _context.SaveChanges();

                return RedirectToAction("Details", new { id = job.JobID });              

                ////Using IJobInfo 
                //var job = new Job();
                //job.JobType = model.JobType;
                //job.NoOfVacancies = model.NoOfVacancies;
                //job.Salary = model.Salary;
                //job.PublishedDate = DateTime.Now;
                //job.Deadline = model.Deadline;
                //job.NoOfVacancies = model.NoOfVacancies;
                //job.Description = model.Description;
                //job.Title = model.Title;

                //job = _jobInfo.Add(job);
                //_jobInfo.Commit();

                //return RedirectToAction("Index", new { id = job.JobID });
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var job = _jobInfo.Get(id)*/;

            //var job = _context.JobVacancy.SingleOrDefaultAsync(m => m.JobID == id);

            var job = _jobInfo.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var job = _jobInfo.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            var model = new Job
            {
                Title = job.Title,
                JobType = job.JobType,
                Salary = job.Salary,
                Description  = job.Description,
                NoOfVacancies = job.NoOfVacancies,
                PublishedDate = job.PublishedDate,
                Deadline = job.Deadline
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (JobViewModel editJob)
        {
            if (ModelState.IsValid)
            {

                var job = _jobInfo.Get(editJob.JobID);

                if (job == null)
                {
                    return NotFound();
                }

                job.Title = editJob.Title;
                job.JobType = editJob.JobType;
                job.Salary = editJob.Salary;
                job.Description = editJob.Description;
                job.NoOfVacancies = editJob.NoOfVacancies;
                job.PublishedDate = editJob.PublishedDate;
                job.Deadline = editJob.Deadline;


                var result = _context.Update(job);

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