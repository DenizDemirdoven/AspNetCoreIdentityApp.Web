using AspNetCoreIdentityApp.Web.Models;
using AspNetCoreIdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AspNetCoreIdentityApp.Web.Extensions;
using AspNetCoreIdentityApp.Web.Services;
using System.Security.Claims;

namespace AspNetCoreIdentityApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _UserManager;
        private readonly SignInManager<AppUser> _SignInManager;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _logger = logger;
            _UserManager = userManager;
            _SignInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Index(){return View();}

        public IActionResult Privacy(){ return View(); }

        public IActionResult SignIn(){return View();}

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl=null)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var hasUser = await _UserManager.FindByEmailAsync(model.Email);

            if(hasUser==null)
            {
                ModelState.AddModelError(string.Empty, "Email ya da şifre yanlış");
                return View();
            }

            var signInResult = await _SignInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "Hesabınız kilitlendi 3 dakika giriş yapamazsınız!" });
                return View();
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelErrorList(new List<string>() { "Email ya da şifre yanlış", $"Başarısız giriş sayısı={await _UserManager.GetAccessFailedCountAsync(hasUser)}" });
                return View();
            }

            if(hasUser.BirthDate.HasValue)
            {
                await _SignInManager.SignInWithClaimsAsync(hasUser, model.RememberMe, new[] { new Claim("birthdate", hasUser.BirthDate.Value.ToString()) });
            }
        
            return Redirect(returnUrl);
        }

        public  IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var identityResult = await _UserManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email },
            request.PasswordConfirm);

            if (!identityResult.Succeeded)
            {
                ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
                return View();
            }

                var campaignExpireClaim = new Claim("CampaignExpireDate", DateTime.Now.AddDays(10).ToString());

                var user = await _UserManager.FindByNameAsync(request.UserName);

                var claimResult = await _UserManager.AddClaimAsync(user, campaignExpireClaim);

            if(!claimResult.Succeeded)
            {
                ModelState.AddModelErrorList(claimResult.Errors.Select(x => x.Description).ToList());
                return View();
            }

                TempData["SuccessMessage"] = "Üyelik kaydı başarıyla gerçekleşti.";
                
                return RedirectToAction(nameof(HomeController.SignUp));
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel request)
        {
            var hasUser = await _UserManager.FindByEmailAsync(request.Email);
            
            if(hasUser==null)
            {
                ModelState.AddModelError(string.Empty, "Bu mail adresine sahip kullanıcı bulunamadı.");
                return View();
            }

            string passwordResetToken = await _UserManager.GeneratePasswordResetTokenAsync(hasUser);

            var passwordResetLink = Url.Action("ResetPassword", "Home", new {userId = hasUser.Id, Token=passwordResetToken}, HttpContext.Request.Scheme);

           await _emailService.SendResetPasswordEmail(passwordResetLink, hasUser.Email);

            TempData["SuccessMessage"] = "Şifre yenileme linki email adresinize gönderilmiştir.";
            return RedirectToAction(nameof(ForgetPassword));
        }

        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"]= userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];

            if(userId==null && token==null)
            {
                throw new Exception("Bir hata meydana geldi.");
            }

            var hasUser = await _UserManager.FindByIdAsync(userId.ToString());

            if (hasUser == null)
            {
                ModelState.AddModelError(String.Empty, "Kullanıcı bulunamamıştır.");
                return View();
            }

            IdentityResult result = await _UserManager.ResetPasswordAsync(hasUser, token.ToString(), request.Password);
            if (result.Succeeded) 
            {
                TempData["SuccessMessage"] = "Şifreniz başarıyla yenilenmiştir.";
            }
            else
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}