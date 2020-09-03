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
    public class TransactionController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Transaction> transactions = db.transactions;
            ViewBag.Transactions = transactions;
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Organization()
        {
            var list = new List<string>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cards) { list.Add(cr.ToString());}
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Organization(Transaction transaction)
        {
            var list = new List<string>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cardse = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cardse) { list.Add(cr.ToString()); }
            ViewBag.list = list;
            if (transaction.CardNumber == null) { ModelState.AddModelError("CardNumber", " Выберите карту"); return View(); }
            if (transaction.RecipientAccount == null) { ModelState.AddModelError("RecipientAccount", " Введите номер счёта"); return View(); }
            if (transaction.ITN == null) { ModelState.AddModelError("ITN", " Введите ИНН"); return View(); }
            if (transaction.Summ <= 0) { ModelState.AddModelError("Summ", " Сумма не может быть отрицательной или равна 0"); return View(); }
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.CardNumber == transaction.CardNumber);
            foreach (var crd in cards)
            {
                if (transaction.Summ > crd.Balance) { ModelState.AddModelError("Summ", " У вас всего "+ crd.Balance + " на балансе"); return View(); }
                transaction.CardId = crd.CardId;
                transaction.Currency = crd.Currency;
                crd.Balance -= transaction.Summ;
                db.bankCards.Attach(crd);
                db.Entry(crd).Property(x => x.Balance).IsModified = true;
            }
            transaction.TransactionType = "Перевод юридическому лицу";
            transaction.Date = DateTime.Today;
            db.transactions.Add(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        [Authorize]
        public ActionResult Person()
        {
            var list = new List<string>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cards) { list.Add(cr.ToString()); }
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Person(Transaction transaction)
        {
            var list = new List<string>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cardss = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cardss) { list.Add(cr.ToString()); }
            ViewBag.list = list;
            if (transaction.CardNumber == null) { ModelState.AddModelError("CardNumber", " Выберите карту"); return View(); }
            if (transaction.RecipientAccount == null) { ModelState.AddModelError("RecipientAccount", " Введите номер счёта"); return View(); }
            if (transaction.ITN == null) { ModelState.AddModelError("ITN", "Введите ИНН"); return View(); }
            if (transaction.Surname == null) { ModelState.AddModelError("Surname", " Введите фамилию"); return View(); }
            if (transaction.Name == null) { ModelState.AddModelError("Name", "Введите имя"); return View(); }
            if (transaction.Patronymic == null) { ModelState.AddModelError("Patronymic", " Введите отчество"); return View(); }
            if (transaction.Summ <= 0) { ModelState.AddModelError("Summ", " Сумма не может быть отрицательной или равна 0"); return View(); }
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.CardNumber == transaction.CardNumber);
            foreach (var crd in cards)
            {
                if (transaction.Summ > crd.Balance) { ModelState.AddModelError("Summ", " У вас всего " + crd.Balance + " на балансе"); return View(); }
                transaction.CardId = crd.CardId;
                transaction.Currency = crd.Currency;
                transaction.Date = DateTime.Today;
                crd.Balance -= transaction.Summ;
                db.bankCards.Attach(crd);
                db.Entry(crd).Property(x => x.Balance).IsModified = true;
            }
            transaction.TransactionType = "Перевод частному лицу";
            db.transactions.Add(transaction);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Authorize]
        public ActionResult Phone()
        {
            var list = new List<string>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cards) { list.Add(cr.ToString()); }
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Phone(Transaction transaction)
        {
            var list = new List<string>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cardse = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cardse) { list.Add(cr.ToString()); }
            ViewBag.list = list;
            if (transaction.CardNumber == null) { ModelState.AddModelError("CardNumber", " Выберите карту"); return View(); }
            if (transaction.PhoneNumber == null) { ModelState.AddModelError("PhoneNumber", " Введите номер телефона"); return View(); }
            if (transaction.Summ <= 0) { ModelState.AddModelError("Summ", " Сумма не может быть отрицательной или равна 0"); return View(); }
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.CardNumber == transaction.CardNumber);
            foreach (var crd in cards)
            {
                if (transaction.Summ > crd.Balance) { ModelState.AddModelError("Summ", " У вас всего " + crd.Balance + " на балансе"); return View(); }
                transaction.CardId = crd.CardId;
                transaction.Currency = crd.Currency;
                transaction.Date = DateTime.Today;
                crd.Balance -= transaction.Summ;
                db.bankCards.Attach(crd);
                db.Entry(crd).Property(x => x.Balance).IsModified = true;
            }
            transaction.TransactionType = "Оплата мобильной связи";
            db.transactions.Add(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Authorize]
        public ActionResult Internal()
        {
            var list = new List<string>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cards) { list.Add(cr.ToString()); }
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Internal(Transaction transaction)
        {
            var list = new List<string>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cardse = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cardse) { list.Add(cr.ToString()); }
            ViewBag.list = list;
            if (transaction.CardNumber == null) { ModelState.AddModelError("CardNumber", " Выберите карту с которой будет осуществлен перевод"); return View(); }
            if (transaction.CardNumber2 == null) { ModelState.AddModelError("CardNumber2", " Выберите карту на которую будет осуществлен перевод"); return View(); }
            if (transaction.CardNumber == transaction.CardNumber2) { ModelState.AddModelError("CardNumber2", " Вы выбрали 2 одинаковых счёта!"); return View(); }
            if (transaction.Summ <= 0) { ModelState.AddModelError("Summ", " Сумма не может быть отрицательной или равна 0"); return View(); }
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.CardNumber == transaction.CardNumber);
            var cards2 = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.CardNumber == transaction.CardNumber2);
            foreach (var crd in cards)
            {
                if (transaction.Summ > crd.Balance) { ModelState.AddModelError("Summ", " У вас всего " + crd.Balance + " на балансе первой карты"); return View(); }
                transaction.CardId = crd.CardId;
                transaction.Currency ="С " + crd.Currency +" карты на ";
                transaction.Date = DateTime.Today;

                if (crd.Currency == "RUB")
                {
                    crd.Balance -= transaction.Summ;
                    foreach (var crd2 in cards2)
                    {
                        if (crd2.Currency == "RUB")
                            crd2.Balance += transaction.Summ;
                        if (crd2.Currency == "USD")
                            crd2.Balance += transaction.Summ / CurrencyChange.USDtoRUB;
                        if (crd2.Currency == "EUR")
                            crd2.Balance += transaction.Summ / CurrencyChange.EURtoRUB;

                        transaction.Currency += crd2.Currency + " карту";
                        db.bankCards.Attach(crd2);
                        db.Entry(crd2).Property(x => x.Balance).IsModified = true;
                    }
                    db.bankCards.Attach(crd);
                    db.Entry(crd).Property(x => x.Balance).IsModified = true;
                }
                if (crd.Currency == "USD")
                {
                    crd.Balance -= transaction.Summ;
                    foreach (var crd2 in cards2)
                    {
                        if (crd2.Currency == "RUB")
                            crd2.Balance += transaction.Summ * CurrencyChange.USDtoRUB;
                        if (crd2.Currency == "USD")
                            crd2.Balance += transaction.Summ;
                        if (crd2.Currency == "EUR")
                            crd2.Balance += transaction.Summ / CurrencyChange.EURtoUSD;

                        transaction.Currency += crd2.Currency + " карту";
                        db.bankCards.Attach(crd2);
                        db.Entry(crd2).Property(x => x.Balance).IsModified = true;
                    }
                    db.bankCards.Attach(crd);
                    db.Entry(crd).Property(x => x.Balance).IsModified = true;
                }
                if (crd.Currency == "EUR")
                {
                    crd.Balance -= transaction.Summ;
                    foreach (var crd2 in cards2)
                    {
                        if (crd2.Currency == "RUB")
                            crd2.Balance += transaction.Summ * CurrencyChange.EURtoRUB;
                        if (crd2.Currency == "USD")
                            crd.Balance += transaction.Summ * CurrencyChange.EURtoUSD;
                        if (crd2.Currency == "EUR")
                            crd2.Balance += transaction.Summ;

                        transaction.Currency += crd2.Currency + " карту";
                        db.bankCards.Attach(crd2);
                        db.Entry(crd2).Property(x => x.Balance).IsModified = true;
                    }
                    db.bankCards.Attach(crd);
                    db.Entry(crd).Property(x => x.Balance).IsModified = true;
                }
            }

            transaction.TransactionType = "Перевод между своими счетами";
            db.transactions.Add(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Search()
        {
            var list = new List<string>();
            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
            foreach (var cr in cards) { list.Add(cr.ToString()); }
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult Search(Transaction transaction)
        {
            return View();
        }

        public ActionResult All(string CardNumber)
        {
            //var hm =
            // from a in db.transactions
            // where (a.CardNumber == CardNumber) &&
            //       (a.CardNumber == CardNumber)
            // select db.transactions;

            //var x1 = (db.transactions.Where((x => x.CardNumber == CardNumber || CardNumber == "")));
            //var x2 = (db.transactions.Where((x => x.CardNumber == CardNumber || CardNumber == "")));

            return View(((db.transactions.Where((x => x.CardNumber == CardNumber || CardNumber == ""))).ToList()));
        }

        [HttpPost]
        public ActionResult Check(int TransactionID)
        {
            //var hm =
            // from a in db.transactions
            // where (a.CardNumber == CardNumber) &&
            //       (a.CardNumber == CardNumber)
            // select db.transactions;

            //var x1 = (db.transactions.Where((x => x.CardNumber == CardNumber || CardNumber == "")));
            //var x2 = (db.transactions.Where((x => x.CardNumber == CardNumber || CardNumber == "")));

            return View(((db.transactions.Where((x => x.TransactionID == TransactionID))).ToList()));
        }

        //[HttpGet]
        //[Authorize]
        //public ActionResult Statement()
        //{
        //    var list = new List<string>();
        //    ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
        //    var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
        //    foreach (var cr in cards) { list.Add(cr.ToString()); }
        //    ViewBag.list = list;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Statement(Transaction statement)
        //{
        //    var list = new List<string>();
        //    ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
        //    var cardse = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId == user.Id);
        //    foreach (var cr in cardse) { list.Add(cr.ToString()); }
        //    ViewBag.list = list;
        //    if (statement.CardNumber == null) { ModelState.AddModelError("CardNumber", " Выберите карту"); return View(); }

        //    var cards = db.bankCards.Include(b => b.ApplicationUser).Where(o => o.CardNumber == statement.CardNumber);

        //    return RedirectToAction("Index");
        //}


        //[Authorize]
        //[HttpPost]
        //public ActionResult TransactionSearch(string CardNumber)
        //{
        //    var alltran = db.transactions
        //    .Include(a => a.CardNumber)
        //    .Where(o => CardNumber.Contains(o.CardNumber)).ToList();
        //        //&& o.RoomTypeId == RoomTypeId
        //        //&& o.HotelId == HotelId
        //        //&& o.NumOfPlaces == NumOfPersons).ToList();
        //    return PartialView(alltran);
        //}
    }
}