using BLL.Abstract;
using MvcUi.Infrastructure;
using MvcUi.ViewModels;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;
using TeamProject.DAL.Entities;

namespace MvcUi.Controllers
{
    [CustomErrorHandler]//куда его лучше положить?
    public class AccountController : Controller
    {
        //переделать под манагеров
        private IAccountManager accountManager;
        public AccountController(IAccountManager accountManager)
        {
            this.accountManager = accountManager;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = accountManager.GetUser(model.Name, model.Password);
                if (user != null)
                {
                    if (user.IsConfirmedEmail)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Не подтвержден Email");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = accountManager.GetUserByEmail(model.Email);
                if (user == null)
                {
                    user = accountManager.CreateUser(model.Email, model.Password);
                    if (user != null)
                    {
                        accountManager.SendEmailToUser(user);
                        return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не удалось создать нового пользователя");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        public string Confirm(string Email)
        {
            return "На почтовый адрес " + Email + " Вам высланы дальнейшие" +
                    "инструкции по завершению регистрации";
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new IndexVM());
        }
        public ActionResult ConfirmEmail(string Token, string Email)
        {
            User user = accountManager.GetUserById(Token);
            if (user != null)
            {
                if (user.Email == Email)
                {
                    user.IsConfirmedEmail = true;
                    accountManager.UpdateUser(user);
                    FormsAuthentication.SetAuthCookie(user.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Confirm", "Account", new { Email = user.Email });
                }
            }
            else
            {
                return RedirectToAction("Confirm", "Account", new { Email = "" });
            }
        }

    }
}
//}
//MailAddress from = new MailAddress("pauluxxx@mail.ru", "Web Registration");
//// кому отправляем
//MailAddress to = new MailAddress(user.Email);
//// создаем объект сообщения
//MailMessage m = new MailMessage(from, to);
//// тема письма
//m.Subject = "Email confirmation";
//                        // текст письма - включаем в него ссылку
//                        m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" +
//                                        "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
//                            Url.Action("ConfirmEmail", "Account", new { Token = user.ID, Email = user.Email }, Request.Url.Scheme));
//                        m.IsBodyHtml = true;
//                        // адрес smtp-сервера, с которого мы и будем отправлять письмо
//                        SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.mail.ru", 2525);
//// логин и пароль
//smtp.EnableSsl = true;
//                        smtp.Credentials = new System.Net.NetworkCredential("pauluxxx@mail.ru", "5898044p");
//                        smtp.Send(m);
              