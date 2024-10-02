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

                    string htmlBody = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" lang=\"en\">\r\n<head>\r\n<title></title>\r\n<meta charset=\"UTF-8\" />\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n<!--[if !mso]>-->\r\n<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />\r\n<!--<![endif]-->\r\n<meta name=\"x-apple-disable-message-reformatting\" content=\"\" />\r\n<meta content=\"target-densitydpi=device-dpi\" name=\"viewport\" />\r\n<meta content=\"true\" name=\"HandheldFriendly\" />\r\n<meta content=\"width=device-width\" name=\"viewport\" />\r\n<meta name=\"format-detection\" content=\"telephone=no, date=no, address=no, email=no, url=no\" />\r\n<style type=\"text/css\">\r\ntable {\r\nborder-collapse: separate;\r\ntable-layout: fixed;\r\nmso-table-lspace: 0pt;\r\nmso-table-rspace: 0pt\r\n}\r\ntable td {\r\nborder-collapse: collapse\r\n}\r\n.ExternalClass {\r\nwidth: 100%\r\n}\r\n.ExternalClass,\r\n.ExternalClass p,\r\n.ExternalClass span,\r\n.ExternalClass font,\r\n.ExternalClass td,\r\n.ExternalClass div {\r\nline-height: 100%\r\n}\r\n.gmail-mobile-forced-width {\r\ndisplay: none;\r\ndisplay: none !important;\r\n}\r\nbody, a, li, p, h1, h2, h3 {\r\n-ms-text-size-adjust: 100%;\r\n-webkit-text-size-adjust: 100%;\r\n}\r\nhtml {\r\n-webkit-text-size-adjust: none !important\r\n}\r\nbody, #innerTable {\r\n-webkit-font-smoothing: antialiased;\r\n-moz-osx-font-smoothing: grayscale\r\n}\r\n#innerTable img+div {\r\ndisplay: none;\r\ndisplay: none !important\r\n}\r\nimg {\r\nMargin: 0;\r\npadding: 0;\r\n-ms-interpolation-mode: bicubic\r\n}\r\nh1, h2, h3, p, a {\r\nline-height: inherit;\r\noverflow-wrap: normal;\r\nwhite-space: normal;\r\nword-break: break-word\r\n}\r\na {\r\ntext-decoration: none\r\n}\r\nh1, h2, h3, p {\r\nmin-width: 100%!important;\r\nwidth: 100%!important;\r\nmax-width: 100%!important;\r\ndisplay: inline-block!important;\r\nborder: 0;\r\npadding: 0;\r\nmargin: 0\r\n}\r\na[x-apple-data-detectors] {\r\ncolor: inherit !important;\r\ntext-decoration: none !important;\r\nfont-size: inherit !important;\r\nfont-family: inherit !important;\r\nfont-weight: inherit !important;\r\nline-height: inherit !important\r\n}\r\nu + #body a {\r\ncolor: inherit;\r\ntext-decoration: none;\r\nfont-size: inherit;\r\nfont-family: inherit;\r\nfont-weight: inherit;\r\nline-height: inherit;\r\n}\r\na[href^=\"mailto\"],\r\na[href^=\"tel\"],\r\na[href^=\"sms\"] {\r\ncolor: inherit;\r\ntext-decoration: none\r\n}\r\n</style>\r\n<style type=\"text/css\">\r\n@media (min-width: 481px) {\r\n.hd { display: none!important }\r\n}\r\n</style>\r\n<style type=\"text/css\">\r\n@media (max-width: 480px) {\r\n.hm { display: none!important }\r\n}\r\n</style>\r\n<style type=\"text/css\">\r\n@media (max-width: 480px) {\r\n.t29,.t3{mso-line-height-alt:0px!important;line-height:0!important;display:none!important}.t4{border-top-left-radius:0!important;border-top-right-radius:0!important;width:480px!important}.t11,.t15,.t19,.t22,.t24,.t27,.t7{width:420px!important}.t24{border-bottom-right-radius:0!important;border-bottom-left-radius:0!important}\r\n}\r\n</style>\r\n<style type=\"text/css\">@media (max-width: 480px) { [class~=\"x_t3\"]{mso-line-height-alt:0px!important;line-height:0px!important;display:none!important;} [class~=\"x_t4\"]{border-top-left-radius:0px!important;border-top-right-radius:0px!important;width:480px!important;} [class~=\"x_t24\"]{border-bottom-right-radius:0px!important;border-bottom-left-radius:0px!important;width:420px!important;} [class~=\"x_t22\"]{width:420px!important;} [class~=\"x_t7\"]{width:420px!important;} [class~=\"x_t11\"]{width:420px!important;} [class~=\"x_t19\"]{width:420px!important;} [class~=\"x_t29\"]{mso-line-height-alt:0px!important;line-height:0px!important;display:none!important;} [class~=\"x_t27\"]{width:420px!important;} [class~=\"x_t15\"]{width:420px!important;}}</style>\r\n<!--[if !mso]>-->\r\n<link href=\"https://fonts.googleapis.com/css2?family=Albert+Sans:wght@400&amp;family=Roboto:wght@400&amp;display=swap\" rel=\"stylesheet\" type=\"text/css\" />\r\n<!--<![endif]-->\r\n<!--[if mso]>\r\n<xml>\r\n<o:OfficeDocumentSettings>\r\n<o:AllowPNG/>\r\n<o:PixelsPerInch>96</o:PixelsPerInch>\r\n</o:OfficeDocumentSettings>\r\n</xml>\r\n<![endif]-->\r\n</head>\r\n<body id=\"body\" class=\"t32\" style=\"min-width:100%;Margin:0px;padding:0px;background-color:#292929;\"><div class=\"t31\" style=\"background-color:#292929;\"><table role=\"presentation\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" align=\"center\"><tr><td class=\"t30\" style=\"font-size:0;line-height:0;mso-line-height-rule:exactly;background-color:#292929;\" valign=\"top\" align=\"center\">\r\n<!--[if mso]>\r\n<v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"true\" stroke=\"false\">\r\n<v:fill color=\"#292929\"/>\r\n</v:background>\r\n<![endif]-->\r\n<table role=\"presentation\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" align=\"center\" id=\"innerTable\"><tr><td><div class=\"t3\" style=\"mso-line-height-rule:exactly;mso-line-height-alt:100px;line-height:100px;font-size:1px;display:block;\">&nbsp;&nbsp;</div></td></tr><tr><td align=\"center\">\r\n<table class=\"t5\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"Margin-left:auto;Margin-right:auto;\">\r\n<tr>\r\n<!--[if mso]>\r\n<td width=\"600\" class=\"t4\" style=\"background-color:#CCD5AE;overflow:hidden;padding:40px 0 40px 0;border-radius:14px 14px 0 0;\">\r\n<![endif]-->\r\n<!--[if !mso]>-->\r\n<td class=\"t4\" style=\"background-color:#CCD5AE;overflow:hidden;width:600px;padding:40px 0 40px 0;border-radius:14px 14px 0 0;\">\r\n<!--<![endif]-->\r\n<table role=\"presentation\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100% !important;\"><tr><td align=\"center\">\r\n<table class=\"t2\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"Margin-left:auto;Margin-right:auto;\">\r\n<tr>\r\n<!--[if mso]>\r\n<td width=\"60\" class=\"t1\">\r\n<![endif]-->\r\n<!--[if !mso]>-->\r\n<td class=\"t1\" style=\"width:60px;\">\r\n<!--<![endif]-->\r\n<div style=\"font-size:0px;\"><img class=\"t0\" style=\"display:block;border:0;height:auto;width:100%;Margin:0;max-width:100%;\" width=\"60\" height=\"60\" alt=\"\" src=\"https://6a92c85b-5ea8-46c4-a535-cea846cdc156.b-cdn.net/e/de69dd4f-7bd0-4384-a107-3e9106331462/d0313111-0d74-4b3a-84f5-9c917eb2ed16.png\"/></div></td>\r\n</tr></table>\r\n</td></tr></table></td>\r\n</tr></table>\r\n</td></tr><tr><td align=\"center\">\r\n<table class=\"t25\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"Margin-left:auto;Margin-right:auto;\">\r\n<tr>\r\n<!--[if mso]>\r\n<td width=\"600\" class=\"t24\" style=\"background-color:#FFFFFF;overflow:hidden;padding:40px 30px 40px 30px;border-radius:0 0 14px 14px;\">\r\n<![endif]-->\r\n<!--[if !mso]>-->\r\n<td class=\"t24\" style=\"background-color:#FFFFFF;overflow:hidden;width:540px;padding:40px 30px 40px 30px;border-radius:0 0 14px 14px;\">\r\n<!--<![endif]-->\r\n<table role=\"presentation\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100% !important;\"><tr><td align=\"center\">\r\n<table class=\"t8\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"Margin-left:auto;Margin-right:auto;\">\r\n<tr>\r\n<!--[if mso]>\r\n<td width=\"540\" class=\"t7\">\r\n<![endif]-->\r\n<!--[if !mso]>-->\r\n<td class=\"t7\" style=\"width:540px;\">\r\n<!--<![endif]-->\r\n<p class=\"t6\" style=\"margin:0;Margin:0;font-family:Albert Sans,BlinkMacSystemFont,Segoe UI,Helvetica Neue,Arial,sans-serif;line-height:24px;font-weight:400;font-style:normal;font-size:24px;text-decoration:none;text-transform:none;direction:ltr;color:#111111;text-align:left;mso-line-height-rule:exactly;\">Merhaba " + appUser.Name + ",</p></td>\r\n</tr></table>\r\n</td></tr><tr><td><div class=\"t9\" style=\"mso-line-height-rule:exactly;mso-line-height-alt:20px;line-height:20px;font-size:1px;display:block;\">&nbsp;&nbsp;</div></td></tr><tr><td align=\"center\">\r\n<table class=\"t12\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"Margin-left:auto;Margin-right:auto;\">\r\n<tr>\r\n<!--[if mso]>\r\n<td width=\"540\" class=\"t11\">\r\n<![endif]-->\r\n<!--[if !mso]>-->\r\n<td class=\"t11\" style=\"width:540px;\">\r\n<!--<![endif]-->\r\n<p class=\"t10\" style=\"margin:0;Margin:0;font-family:Albert Sans,BlinkMacSystemFont,Segoe UI,Helvetica Neue,Arial,sans-serif;line-height:24px;font-weight:400;font-style:normal;font-size:14px;text-decoration:none;text-transform:none;direction:ltr;color:#111111;text-align:left;mso-line-height-rule:exactly;mso-text-raise:3px;\">Hesabını doğrulamak için yalnızca bir adım kaldı. Aşağıda yer alan onay kodu ile hesabını doğrulayabilirsin.</p></td>\r\n</tr></table>\r\n</td></tr><tr><td><div class=\"t14\" style=\"mso-line-height-rule:exactly;mso-line-height-alt:20px;line-height:20px;font-size:1px;display:block;\">&nbsp;&nbsp;</div></td></tr><tr><td align=\"center\">\r\n<table class=\"t16\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"Margin-left:auto;Margin-right:auto;\">\r\n<tr>\r\n<!--[if mso]>\r\n<td width=\"540\" class=\"t15\">\r\n<![endif]-->\r\n<!--[if !mso]>-->\r\n<td class=\"t15\" style=\"width:540px;\">\r\n<!--<![endif]-->\r\n<h1 class=\"t13\" style=\"margin:0;Margin:0;font-family:Roboto,BlinkMacSystemFont,Segoe UI,Helvetica Neue,Arial,sans-serif;line-height:34px;font-weight:400;font-style:normal;font-size:28px;text-decoration:none;text-transform:none;direction:ltr;color:#333333;text-align:center;mso-line-height-rule:exactly;mso-text-raise:2px;\">" + appUser.ConfirmCode + "</h1></td>\r\n</tr></table>\r\n</td></tr><tr><td><div class=\"t17\" style=\"mso-line-height-rule:exactly;mso-line-height-alt:20px;line-height:20px;font-size:1px;display:block;\">&nbsp;&nbsp;</div></td></tr><tr><td align=\"center\">\r\n<table class=\"t20\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"Margin-left:auto;Margin-right:auto;\">\r\n<tr>\r\n<!--[if mso]>\r\n<td width=\"540\" class=\"t19\">\r\n<![endif]-->\r\n<!--[if !mso]>-->\r\n<td class=\"t19\" style=\"width:540px;\">\r\n<!--<![endif]-->\r\n<p class=\"t18\" style=\"margin:0;Margin:0;font-family:Albert Sans,BlinkMacSystemFont,Segoe UI,Helvetica Neue,Arial,sans-serif;line-height:24px;font-weight:400;font-style:normal;font-size:14px;text-decoration:none;text-transform:none;direction:ltr;color:#111111;text-align:left;mso-line-height-rule:exactly;mso-text-raise:3px;\">Teşekkürler!</p></td>\r\n</tr></table>\r\n</td></tr><tr><td align=\"center\">\r\n<table class=\"t23\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"Margin-left:auto;Margin-right:auto;\">\r\n<tr>\r\n<!--[if mso]>\r\n<td width=\"540\" class=\"t22\">\r\n<![endif]-->\r\n<!--[if !mso]>-->\r\n<td class=\"t22\" style=\"width:540px;\">\r\n<!--<![endif]-->\r\n<p class=\"t21\" style=\"margin:0;Margin:0;font-family:Albert Sans,BlinkMacSystemFont,Segoe UI,Helvetica Neue,Arial,sans-serif;line-height:24px;font-weight:400;font-style:normal;font-size:14px;text-decoration:none;text-transform:none;direction:ltr;color:#111111;text-align:left;mso-line-height-rule:exactly;mso-text-raise:3px;\">Identity Project Admin</p></td>\r\n</tr></table>\r\n</td></tr></table></td>\r\n</tr></table>\r\n</td></tr><tr><td align=\"center\">\r\n<table class=\"t28\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" style=\"Margin-left:auto;Margin-right:auto;\">\r\n<tr>\r\n<!--[if mso]>\r\n<td width=\"600\" class=\"t27\" style=\"padding:20px 30px 20px 30px;\">\r\n<![endif]-->\r\n<!--[if !mso]>-->\r\n<td class=\"t27\" style=\"width:540px;padding:20px 30px 20px 30px;\">\r\n<!--<![endif]-->\r\n<p class=\"t26\" style=\"margin:0;Margin:0;font-family:Albert Sans,BlinkMacSystemFont,Segoe UI,Helvetica Neue,Arial,sans-serif;line-height:24px;font-weight:400;font-style:normal;font-size:14px;text-decoration:none;text-transform:none;direction:ltr;color:#878787;text-align:left;mso-line-height-rule:exactly;mso-text-raise:3px;\">Identity Project © 2024</p></td>\r\n</tr></table>\r\n</td></tr><tr><td><div class=\"t29\" style=\"mso-line-height-rule:exactly;mso-line-height-alt:80px;line-height:80px;font-size:1px;display:block;\">&nbsp;&nbsp;</div></td></tr></table></td></tr></table></div><div class=\"gmail-mobile-forced-width\" style=\"white-space: nowrap; font: 15px courier; line-height: 0;\">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;\r\n</div></body>\r\n</html>";

                    bodyBuilder.HtmlBody = htmlBody;

                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Identity Project Onay Kodu";

					SmtpClient client = new SmtpClient();
					client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("harunucan3330@gmail.com", "tknb favw bkzv mdjc");
                    client.Send(mimeMessage);
					client.Disconnect(true);

                    TempData["Mail"] = appUserRegisterDto.Email;

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
