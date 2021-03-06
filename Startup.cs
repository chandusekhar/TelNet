﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using TelNet.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
[assembly: OwinStartupAttribute(typeof(TelNet.Startup))]
namespace TelNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          createRolesandUsers();
          
        }
        // In this method we will create default User roles and Admin user for login    
        private void createRolesandUsers()
        {
            Models.ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user2 = UserManager.FindByEmail("menadzer@telnet.ba");
            var result12 = UserManager.AddToRole(user2.Id, "Manager");

            user2 = UserManager.FindByEmail("zaposlenik@telnet.ba");
            result12 = UserManager.AddToRole(user2.Id, "Employee");

            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   
                
              /*  var user = new ApplicationUser();
                user.UserName = "Emina";
                user.Email = "huskic.emina@gmail.com";
                string userPWD = "Emina";
                var chkUser = UserManager.Create(user, userPWD);
                */
                //Add default User to Role Admin    
                var user = UserManager.FindByEmail("huskic.emina@gmail.com");

                var result1 = UserManager.AddToRole(user.Id, "Admin");


            }
            else
            {
              
                var user = UserManager.FindByEmail("huskic.emina@gmail.com");
                var result1 = UserManager.AddToRole(user.Id, "Admin");
    
    }

            // creating Creating Manager role     
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }

        }
    }
}

