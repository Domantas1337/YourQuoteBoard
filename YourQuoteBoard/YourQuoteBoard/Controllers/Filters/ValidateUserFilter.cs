using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YourQuoteBoard.Controllers;

namespace YourQuoteBoard.Filters
{
    public class ValidateUserFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is BaseController controller)
            {
                var userId = controller.GetUserId();
                context.HttpContext.Items["UserId"] = userId;

                if (userId == null)
                {
                    context.Result = new NotFoundObjectResult("User not found.");
                }
            }
            else
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Optional: Post-processing logic
        }
    }
}
