using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage ="ContacId is Required..")]
        public int ContactID {  get; set; }

        [Required(ErrorMessage ="FirstName is Required..")]
        [StringLength(15,MinimumLength=5, ErrorMessage ="Name Must be between 5 and 15 characters")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "LAstname is Required..")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "LastNAme must consists between 6 and 15 characters")]

        public string LastName { get; set; }

        [Required]
        public string CompanyName {  get; set; }

        [Required(ErrorMessage ="EMialId is required..")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}" ,ErrorMessage ="Inavalid Email Address..")]
        public string EmailId {  get; set; }

        [Required(ErrorMessage ="Mobile no is mandatory..")]
        [RegularExpression(@"^\d{10}$" ,ErrorMessage ="Invalid MobileNUmber")]
        public long MobileNo {  get; set; }

        [Required(ErrorMessage ="Designation is mandatory..")]
        public string Designation {  get; set; }
    }
}
