using System.Collections.Generic;
using System.Linq;
using JobSearch.Data;
using JobSearch.Entities;

namespace JobSearch.Services
{
    public class JobInfo : IJobInfo
    {
        private ApplicationDbContext _context;

        public JobInfo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Job Add(Job model)
        {
            // _context.Add(model);
            _context.JobVacancy.Add(model);
            return model;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Job> GetAll()
        {
            return _context.JobVacancy;
        }

        public Job Get(int id)
        {
            //return _context.JobVacancy.Where(j => j.JobID == id).SingleOrDefault();
            return _context.JobVacancy.Where(j => j.JobID == id).SingleOrDefault();
        }
    }
}