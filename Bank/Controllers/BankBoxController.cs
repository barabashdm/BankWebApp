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
    public class BankBoxController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<BankBox> bankboxes = db.bankboxes;
            ViewBag.BankBoxes = bankboxes;
            return View();
        }

        [HttpGet]
        public ActionResult BankBoxView(string ApplicationUserId)
        {
            return View(((db.bankboxes.Where((x => x.ApplicationUserId == ApplicationUserId || ApplicationUserId == ""))).ToList()));
        }

        [HttpPost]
        public ActionResult Cameras(int TransactionID)
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
    }
}