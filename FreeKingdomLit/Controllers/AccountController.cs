using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using FreeKingdomLit.Models;
using FreeKingdomLit.ViewModels;

namespace FreeKingdomLit.Controllers
{
  public class AccountController : Controller
  {
    private readonly FreeKingdomLitContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, FreeKingdomLitContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      if (ModelState.IsValid)
      {
        ApplicationUser user = new ApplicationUser { UserName = model.Email };
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
      }
      return View();
    }
  }
}