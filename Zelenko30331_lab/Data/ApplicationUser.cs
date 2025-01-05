using Microsoft.AspNetCore.Identity;

namespace Zelenko30331_lab.Data
{
    public class ApplicationUser : IdentityUser
    {
        public byte[]? Avatar { get; set; }
        public string MimeType { get; set; } = string.Empty;
    }
}
