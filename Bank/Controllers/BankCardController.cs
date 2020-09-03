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
    public class BankCardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<BankCard> bankCards = db.bankCards;
            ViewBag.BankCards = bankCards;
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            return View(cards);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var list = new List<String>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cards)
            {
                list.Add(cr.CardNumber);
            }
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Create(BankCard bankCard)
        {
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            bankCard.ApplicationUser = user;
            bankCard.ApplicationUserId = user.Id;
            db.bankCards.Add(bankCard);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            BankCard b = db.bankCards.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BankCard b = db.bankCards.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.bankCards.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RedirectToTransaction(string Dati, int roomID)
        {
            //получить даты
            var dates = Dati.Split('|');
            var arrivalDate = dates[0];
            var returnDate = dates[1];
            //создать модель заказа
            return View();
        }

    }
}