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
    public class CardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cards
        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Card> cards = db.Cards;
            ViewBag.Cards = cards;

            ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
            var ccards = db.Cards.Include(b => b.ApplicationUser).Where(o => o.ApplicationUserId != null);
            return View(ccards);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Secondname");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Card card)
        {
            db.Cards.Add(card);
            db.SaveChanges();

            return RedirectToAction("Index");
        }




        //[Authorize]
        //public ActionResult Create()
        //{
        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Secondname");
        //    ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNum");
        //    ViewBag.HotelId = new SelectList(db.Hotels, "HotelId", "Name");
        //    ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "RoomTypeId", "Name");
        //    return View();
        //}
        //// GET: Bookings/Details/5
        //[Authorize]
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpS tatusCode.BadRequest);
        //    }
        //    Booking booking = await db.Bookings.FindAsync(id);
        //    if (booking == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(booking);
        //}

        ////Создает модель заказа по датам и комнате
        //private Booking GetBooking(DateTime arrivalDate, DateTime returnDate, int roomID)
        //{
        //    Room room = db.Rooms.Include(r => r.Hotel).Include(r => r.RoomType).Where(r => r.RoomId == roomID).FirstOrDefault();
        //    ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
        //    return new Booking
        //    {
        //        ApplicationUserId = user.Id,
        //        Room = room,
        //        RoomId = room.RoomId,
        //        ArrivalDate = (arrivalDate),
        //        ReturnDate = (returnDate),
        //        NumOfPersons = room.NumOfPlaces,
        //        PriceFor1Day = room.Price
        //    };
        //}

        //public ActionResult RedirectToBooking(string Dati, int roomID)
        //{
        //    //получить даты
        //    var dates = Dati.Split('|');
        //    var arrivalDate = dates[0];
        //    var returnDate = dates[1];
        //    //создать модель заказа
        //    Booking booking = GetBooking(Convert.ToDateTime(arrivalDate), Convert.ToDateTime(returnDate), roomID);
        //    return View("Create",booking);
        //}

        //// GET: Bookings/Create



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "ApplicationUserId,RoomId,ArrivalDate,ReturnDate")] Booking booking)
        //{
        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Secondname", booking.ApplicationUserId);
        //    ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNum", booking.RoomId);

        //    if (ModelState.IsValid)
        //    {

        //        if (booking.ArrivalDate > booking.ReturnDate || Math.Abs((booking.ArrivalDate - booking.ReturnDate).Days) >= 30)
        //            return View("PageError");
        //        ApplicationUser user = db.Users.Where(o => o.UserName == HttpContext.User.Identity.Name).First();
        //        var bookings = db.Bookings.Include(b => b.ApplicationUser).Include(b => b.Room).Include(b => b.Room.Hotel).Where(o => o.ApplicationUserId == user.Id).ToList();
        //        int c = bookings.Count();
        //        if (c >= 1)
        //        {
        //            var lastBb = bookings.Last();
        //            if (!((lastBb.ReturnDate > booking.ArrivalDate && lastBb.ArrivalDate > booking.ReturnDate) || (lastBb.ReturnDate < booking.ArrivalDate)))
        //                return View("PageError2");

        //        }
        //        if (c >= 2)
        //        {
        //            var secondlastB = bookings[c-2]; // предпоследняя бронь
        //            var lastB = bookings.Last();
        //            if (lastB.ReturnDate > DateTime.Now && secondlastB.ReturnDate > DateTime.Now) //проверка на актуальность брони
        //                return View("PageError");
        //        }

        //        List<int> roomsID = new List<int>();
        //        List<Room> checkRooms = new List<Room>();
        //        checkRooms = db.Rooms.ToList();
        //        List<Booking> checkBookings = new List<Booking>();
        //        checkBookings = db.Bookings.ToList();

        //        foreach (Room element in checkRooms)
        //        {
        //            roomsID.Add(element.RoomId);
        //        }

        //        foreach (Room el in checkRooms)
        //        {
        //            foreach (Booking element in checkBookings)
        //            {
        //                if (el.RoomId == element.RoomId)
        //                {
        //                    if (!((element.ArrivalDate > booking.ReturnDate) || (element.ReturnDate < booking.ArrivalDate)))
        //                    {
        //                        if (!(element.ReturnDate < DateTime.Now))
        //                            roomsID.Remove(element.RoomId);
        //                    }
        //                }

        //            }
        //        }

        //        if (!(roomsID.Contains(booking.RoomId)))
        //            return View("PageError4");

        //        booking = GetBooking(booking.ArrivalDate,booking.ReturnDate, booking.RoomId);
        //        db.Bookings.Add(booking);
        //        await db.SaveChangesAsync();
        //        //успешно
        //        return View("Success");
        //    }
        //    return View(booking);
        //}

        //[Authorize]
        //[HttpPost]
        //public ActionResult RoomSearch (int HotelId, int RoomTypeId, DateTime ArrivalDate, DateTime ReturnDate, int NumOfPersons)
        //{
        //    if (ArrivalDate>ReturnDate)
        //        return PartialView("Error");
        //    if (NumOfPersons <= 0)
        //        return PartialView("Error2");
        //    if (ArrivalDate < DateTime.Now)
        //        return PartialView("Error3");
        //    if (Math.Abs((ArrivalDate - ReturnDate).Days) >= 30 || Math.Abs((ArrivalDate - ReturnDate).Days) < 1)
        //        return PartialView("Error4");
        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Secondname");
        //    ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNum");
        //    ViewBag.HotelId = new SelectList(db.Hotels, "HotelId", "Name");
        //    ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "RoomTypeId", "Name");
        //    ViewBag.Dates = ArrivalDate + "|" + ReturnDate;

        //    List<int> roomsID = new List<int>();
        //    List<Room> checkRooms = new List<Room>();
        //    checkRooms = db.Rooms.ToList();
        //    List<Booking> checkBookings = new List<Booking>();
        //    checkBookings = db.Bookings.ToList();

        //    foreach (Room element in checkRooms)
        //    {
        //        roomsID.Add(element.RoomId);
        //    }

        //    foreach (Room el in checkRooms)
        //    {   
        //        foreach (Booking element in checkBookings)
        //        {
        //            if (el.RoomId == element.RoomId)
        //            {
        //                if (!((element.ArrivalDate >= ReturnDate) || (element.ReturnDate <= ArrivalDate)))
        //                {
        //                    roomsID.Remove(element.RoomId);
        //                }
        //            }

        //        }
        //    }

        //    var allrooms = db.Rooms
        //        .Include(a => a.Hotel)
        //        .Include(a => a.RoomType)
        //        .Where(o => roomsID.Contains(o.RoomId) 
        //        && o.RoomTypeId == RoomTypeId 
        //        && o.HotelId == HotelId 
        //        && o.NumOfPlaces == NumOfPersons).ToList();
        //    return PartialView(allrooms);
        //}
        //[Authorize]
        //public ActionResult Search(int HotelId = -1)
        //{
        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Secondname");
        //    ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNum");
        //    ViewBag.HotelId = new SelectList(db.Hotels, "HotelId", "Name");
        //    ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "RoomTypeId", "Name");
        //    return View();
        //}

        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Booking booking = await db.Bookings.FindAsync(id);
        //    if (booking == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Firstname", booking.ApplicationUserId);
        //    ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNum", booking.RoomId);
        //    return View(booking);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "BookingId,ApplicationUserId,RoomId,ArrivalDate,ReturnDate,NumOfPersons,PriceFor1Day,PriceFull")] Booking booking)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(booking).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Firstname", booking.ApplicationUserId);
        //    ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNum", booking.RoomId);
        //    return View(booking);
        //}

        //// GET: Bookings/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNum");
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Booking booking = await db.Bookings.FindAsync(id);
        //    if (booking == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(booking);
        //}

        //// POST: Bookings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{

        //    Booking booking = await db.Bookings.FindAsync(id);
        //    if (booking.ArrivalDate < DateTime.Now)
        //        return View("PageError3");
        //    db.Bookings.Remove(booking);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
