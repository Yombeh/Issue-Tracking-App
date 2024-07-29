using Microsoft.AspNetCore.Authentication;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Issue_Tracking_App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace Issue_Tracking_App.Transformer
{

    public class TransactionLogsClaimsTransformation : IClaimsTransformation
    {
        private readonly ApplicationDbContext _context;
        private readonly string roles;

        //Constructor to inject the database context
        public TransactionLogsClaimsTransformation(ApplicationDbContext context)
        {
            _context = context;
        }

        //method to transform the claims for the given User
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            try
            {
                //Get The claims Identity from the principal
                var id = ((ClaimsIdentity)principal.Identity);
                //Extract the UserName from the Identity, assuming the format Domain/Name.
                var username = ((ClaimsIdentity)principal.Identity).Name.Split('\\')[1];
                //Query the database to get roles associated with the userName 
                var roles = _context.differentUserRoles.Where(a => a.UserName == username);
                //Check if any role was found
                if (roles.Any())
                {
                    // Add each role as a claim to the identity
                    roles.ToList().ForEach(c => id.AddClaim(new Claim(c.role, c.values)));
                }

                // return the transform principal with added claims

                return Task.FromResult(principal);
            }
            catch (Exception x)
            {
                //Log the error to the console incase of any Error
                Console.WriteLine($"error loading custom claims due {x.Message}");
                // return original principal without modification
                return Task.FromResult<ClaimsPrincipal>(principal);
            }
        }
    }
}







        