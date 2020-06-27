using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApi.Auth.Areas.Identity.Pages.Test
{
    [Authorize]
    public class AuthorizePage : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}
