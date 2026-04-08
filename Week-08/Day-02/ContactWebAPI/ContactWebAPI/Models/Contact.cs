using System.ComponentModel.DataAnnotations;

namespace ContactWebAPI.Models
{
    public class Contact
    {
        public int ContactId {  get; set; }
        [Required]
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId {  get; set; }
        [Required]
        public long MobileNo {  get; set; }
        public string Designation {  get; set; }
        
    }
}
