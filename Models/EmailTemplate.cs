using Microsoft.AspNetCore.Identity;

namespace EmailTemplateApp.Models
{
    // EmailTemplate.cs
    public class EmailTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int VisitCount { get; set; }
    }

    // ApplicationUser.cs
    public class ApplicationUser : IdentityUser
    {
        public int EmailTemplateId { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
    }


}
