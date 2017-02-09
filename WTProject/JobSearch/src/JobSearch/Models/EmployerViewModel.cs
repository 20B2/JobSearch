using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace JobSearch.Models
{
    public class EmployerViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }
       
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Name of the Company")]
        public virtual string CompanyName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public virtual string Address { get; set; }

        [Required]
        [Display(Name = "Company Description")]
        public virtual string CompanyDescription { get; set; }

        [Required, Phone]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public virtual string Phone { get; set; }
    }
}