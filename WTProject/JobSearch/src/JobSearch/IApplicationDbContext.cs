using JobSearch.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Job> JobVacancy { get; set; }
    }
}