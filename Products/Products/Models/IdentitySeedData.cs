
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin"; 
        private const string adminPassword = "@oT00000";

        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        { IdentityUser user = await userManager.FindByIdAsync(adminUser); 
            if (user == null) 
            { 
                user = new IdentityUser("Admin"); await userManager.CreateAsync(user, adminPassword); 
            } 
        }
    }
}
