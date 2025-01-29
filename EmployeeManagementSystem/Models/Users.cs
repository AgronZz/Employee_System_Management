using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
