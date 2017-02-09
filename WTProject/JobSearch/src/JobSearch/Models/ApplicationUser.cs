using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobSearch.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobSearch.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {
        
        public virtual string CompanyName { get; set; }

        
        public virtual string Address { get; set; }

        
        public virtual string CompanyDescription { get; set; }

        
        public virtual string Phone { get; set; }


        public ICollection<Job> Jobs { get; set; }
    }
}
