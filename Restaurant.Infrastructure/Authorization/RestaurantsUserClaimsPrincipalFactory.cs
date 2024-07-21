using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurant.Domain.Entities;
using System.Security.Claims;

namespace Restaurant.Infrastructure.Authorization
{
    public class RestaurantsUserClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
    {
        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var id = await GenerateClaimsAsync(user);

            if(user.Nationality != null)
            {
                id.AddClaim(new Claim(AppClaimType.Nationality, user.Nationality));
            }

            if(user.DateofBirth != null)
            {
                id.AddClaim(new Claim(AppClaimType.DateOfBirth, user.DateofBirth.Value.ToString("yyyy-MM-dd")));

            }

            return new ClaimsPrincipal(id);
        }
    }
}
