using System.Security.Claims;

namespace TravelManagement.Services.Authentication
{
    public static class ClaimsHelper
    {
        internal static string GetLoggedUserId(this ClaimsPrincipal claims) =>
            claims.FindFirstValue("LoggedUserId");
    }
}
