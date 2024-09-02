using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace YourQuoteBoard.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected internal string? GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
