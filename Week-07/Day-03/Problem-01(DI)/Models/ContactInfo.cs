using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class ContactInfo
    {
        public int ContactId {  get; set; }
        [Required(ErrorMessage ="FirstName is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "CompanyName is Required")]
        public string CompanyName {  get; set; }
       
        [Required(ErrorMessage ="Email Id is Mandatory")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
        public string EmailId {  get; set; }
        
        [RegularExpression("^[6-9]\\d{9}$")]
        [Required(ErrorMessage ="Enter Your Mobile Number")]
        public string MobileNo {  get; set; }

        [Required(ErrorMessage ="Enter Your Designation")]
        public string Designation {  get; set; }
    }
}
