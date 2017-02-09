using System;
using System.Linq;
using JobSearch.Models;
using JobSearch.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JobSearch.Enums;
using JobSearch.Entities;
using System.Collections.Generic;
using JobSearch.Data;
using System.Threading.Tasks;

namespace JobSearch.Controllers
{
    public class JobsSearchController:Controller
    {
        private readonly IJobInfo _jobInfo;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public JobsSearchController(IJobInfo jobInfo,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _jobInfo = jobInfo;
            _context = context; 
            _userManager = userManager;
        }

        //public IActionResult Index(int page = 1)
        //{
        //    int pageSize = 5;

        //    PaginationSet<Job> pagedSet = null;

        //    int currentPage = page;
        //    int currentPageSize = pageSize;

        //    List<Job> _jobs = null;
        //    int _totalJobs= new int();

        //    //var u = _userManager.Users.ToList();
        //    var j = _jobInfo.GetAll().ToList();

        //    _jobs = j
        //        .OrderBy(p => p.Deadline)
        //        .Skip(((currentPage) * currentPageSize) - currentPage)
        //        .Take(currentPageSize)
        //        .ToList();

        //    var item = _jobs;
        //    _totalJobs = j.Count() ;

        //    pagedSet = new PaginationSet<Job>()
        //    {
        //        Page = currentPage,
        //        TotalCount = _totalJobs,
        //        TotalPages = (int)Math.Ceiling(_totalJobs / (double)currentPageSize),
        //        Items = item
        //    };

        //    //ViewBag.Roles = _roleManager.Roles.ToList().ToListViewModel();

        //    return View(pagedSet);
        //}


        public IActionResult Index(string searchString,
            string location,
            JobType jobType,
            string salary)
        {
            var jobs = _jobInfo.GetAll();

            //var jobTypes = from j in jobs select j.JobType;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(j => j.Title.ToUpper().Contains(searchString.ToUpper()));
            }
            //if(!String.IsNullOrEmpty(location))
            //{
            //    jobs = jobs.Where(j => j.Employer.Address.ToUpper().Contains(location.ToUpper()));
            //}
            //if(!String.IsNullOrEmpty(jobType.ToString()))
            //{
            //    if(jobType.ToString() == "0")
            //        jobs = jobs.Where(j => j.JobType.Equals(jobType));
            //}

            //return View(jobs.ToList());
            return View(jobs.ToList());
        }

    }
}