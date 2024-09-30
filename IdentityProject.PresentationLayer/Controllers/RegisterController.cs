using IdentityProject.DtoLayer.Dtos.AppUserDtos;
using IdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace IdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
				Random random = new Random();
                int code = random.Next(100_000, 1_000_000);
				AppUser appUser = new AppUser()
                {
                    Name = appUserRegisterDto.Name,
                    SurName = appUserRegisterDto.SurName,
                    Email = appUserRegisterDto.Email,
                    UserName = appUserRegisterDto.UserName,
                    City = "deneme",
                    District = "deneme",
                    ImageUrl = "deneme",
                    ConfirmCode = code
				};

                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddrFrom = new MailboxAddress("Identity Project Admin", "harunucan3330@gmail.com");
					MailboxAddress mailboxAddrTo = new MailboxAddress(appUser.Name, appUser.Email);

					mimeMessage.From.Add(mailboxAddrFrom);
					mimeMessage.To.Add(mailboxAddrTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = $"Merhaba {appUser.Name} {appUser.SurName}, <br> <h2>Hesabınızı Aktifleştirmek İçin Onay Kodunuz :</h2> <br> <h1>{code}</h1>";
					mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Identity Project Onay Kodu";

					SmtpClient client = new SmtpClient();
					client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("harunucan3330@gmail.com", "tknb favw bkzv mdjc");
                    client.Send(mimeMessage);
					client.Disconnect(true);

					return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
			return View();
		}
	}
}
