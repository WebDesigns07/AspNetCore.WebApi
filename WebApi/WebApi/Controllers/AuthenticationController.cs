using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Best Practice for Authentication 
    /// </summary>
    public class AuthenticationController : ControllerBase
    {
//         public async Task<IActionResult> OnGetAsync(Guid documentId)
// {
//     Document = _documentRepository.Find(documentId);

//     if (Document == null)
//     {
//         return new NotFoundResult();
//     }

//     var authorizationResult = await _authorizationService
//             .AuthorizeAsync(User, Document, Operations.Read);

//     if (authorizationResult.Succeeded)
//     {
//         return Page();
//     }
//     else if (User.Identity.IsAuthenticated)
//     {
//         return new ForbidResult();
//     }
//     else
//     {
//         return new ChallengeResult();
//     }
// }
// [AllowAnonymous]
// public class Details2Model : DI_BasePageModel
// {
//     public Details2Model(
//         ApplicationDbContext context,
//         IAuthorizationService authorizationService,
//         UserManager<IdentityUser> userManager)
//         : base(context, authorizationService, userManager)
//     {
//     }

//     public Contact Contact { get; set; }

//     public async Task<IActionResult> OnGetAsync(int id)
//     {
//         Contact = await Context.Contact.FirstOrDefaultAsync(m => m.ContactId == id);

//         if (Contact == null)
//         {
//             return NotFound();
//         }

//         if (!User.Identity.IsAuthenticated)
//         {
//             return Challenge();
//         }

//         var isAuthorized = User.IsInRole(Constants.ContactManagersRole) ||
//                            User.IsInRole(Constants.ContactAdministratorsRole);

//         var currentUserId = UserManager.GetUserId(User);

//         if (!isAuthorized
//             && currentUserId != Contact.OwnerID
//             && Contact.Status != ContactStatus.Approved)
//         {
//             return Forbid();
//         }

//         return Page();
//     }
// }
    }
}
