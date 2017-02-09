using System.Collections.Generic;
using JobSearch.Entities;

namespace JobSearch.Services
{
    public interface IJobInfo
    {
        Job Get(int id);
        IEnumerable<Job> GetAll();
        Job Add(Job model);
        void Commit();
    }
}