using System;
using System.Linq;
using System.Security.Claims;

namespace GymDiaryAPI.Helpers
{
    public class UserProfileHelper
    {
        public static int GetCurrentUserId(ClaimsPrincipal claimsPrincipal)
        {
            return Convert.ToInt32(claimsPrincipal.Claims.First(x => x.Type == "UserId").Value);
        }
    }
}