using JobSearch.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using JobSearch.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearch.Models
{
    public class JobViewModel
   {
        public int JobID { get; set; }

       [DisplayAttribute(Name = "Job Title")]
       public virtual string Title { get; set; }

       [Required]
       [DisplayAttribute(Name = "Type of Job")]
       public virtual JobType? JobType { get; set; }

       [Required]
       [DisplayAttribute(Name = "Expected Salary")]
       public virtual decimal Salary { get; set; }

       [Required]
       [DisplayAttribute(Name = "Job Description")]
       public virtual string Description { get; set; }

       [Required]
       [DisplayAttribute(Name = "No of Vacancies")]
       public virtual int NoOfVacancies { get; set; }

       [DisplayAttribute(Name = "Published Date")]
       [DataType(DataType.Date)]
       public virtual DateTime PublishedDate { get; set; }

       [Required]
       [DisplayAttribute(Name = "Deadline")]
       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       public virtual DateTime Deadline { get; set; }

       public int UserID { get; set; }
       [ForeignKey("UserID")]
       public ApplicationUser User { get; set; }
   }
}