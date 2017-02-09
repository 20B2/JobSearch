using System.ComponentModel.DataAnnotations;

namespace JobSearch.Enums
{
    public enum JobType{
        [Display(Name="Select Job Type")]
        JobType,
        [Display(Name="Full Time")]
        FullTime,  
        [DisplayAttribute(Name="Part Time")]
        PartTime, 
        [DisplayAttribute(Name="Internship")]
        Internship, 
        Volunteer
    }

    public enum Salary{
        [Display(Name ="Select Salary Range")]
        SalaryRange,
        [Display(Name="10,000-20,000")]
        Above10000, 
        [Display(Name="10,000-30,000")]
        Above20000, 
        [Display(Name="30,000-40,000")]
        Above30000,
        [Display(Name="40,000-50,000")]
        Above40000, 
        [Display(Name="50,000+")]
        Above50000
    }

}