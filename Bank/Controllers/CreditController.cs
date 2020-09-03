using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bank.Models;
using Microsoft.AspNet.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace Bank.Controllers
{
    public class CreditController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Credit> credits = db.credits;
            ViewBag.Credits = credits;
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var crlist = db.credits.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            return View(crlist);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Credit credit)
        {
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var credits = db.credits.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            Credit crdt = new Credit();
            foreach (var cr in credits) { crdt = cr; }
            if ((credits.Count() > 0) && (crdt.IssueDate.AddDays(30) > DateTime.Today )){ ModelState.AddModelError("Purp", " Вы не можете взять новый кредит так рано, подождите "+ (crdt.IssueDate.AddDays(30)).Subtract(DateTime.Today).Days + " дней"); return View(); }
            if (credit.Purp == null) { ModelState.AddModelError("Purp", " Укажите цель кредита"); return View(); }
            if (credit.Summ <= 0) { ModelState.AddModelError("Summ", " Сумма не может быть отрицательной или равна 0"); return View(); }
            if (credit.Summ < 10000) { ModelState.AddModelError("Summ", " Минимальная сумма кредита 10 000 рублей"); return View(); }
            if (credit.Summ > 100000) { ModelState.AddModelError("Summ", " Вы не можете оформить кредит на сумму более 100 000 рублей в онлайн банке"); return View(); }

            Random random = new Random();
            BankCard bk = new BankCard();
            bk.ApplicationUser = user;
            bk.ApplicationUserId = user.Id;
            bk.Balance = credit.Summ;
            //bk.CardId = random.Next(500, 2000);
            const string chars = "0123456789";
            string str = "";
            str += new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray()); str += " ";
            str += new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray()); str += " ";
            str += new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray()); str += " ";
            str += new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
            bk.CardNumber = str;
            bk.Currency = "RUB";
            bk.ReceivingDate = DateTime.Today;
            bk.ValidUntil = DateTime.Today.AddDays(365);
            credit.CardID = bk.CardId;
            credit.BankCard = new BankCard();
            credit.ApplicationUser = user;
            credit.IssueDate = DateTime.Today;
            credit.DeadLine = DateTime.Today.AddDays(365);
            credit.Percent = (decimal)0.13;
            credit.LeftToPay = credit.Summ + credit.Summ * credit.Percent;

            db.bankCards.Add(bk);
            db.credits.Add(credit);
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}