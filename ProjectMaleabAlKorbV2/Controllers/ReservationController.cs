using ProjectMaleabAlKorbV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMaleabAlKorbV2.Controllers
{
    public class ReservationController : Controller
    {
        MalaebAlKorbEntities db = new MalaebAlKorbEntities();
        // GET: Reservation
        public ActionResult Index()
        {
            //if(Session["emails"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            return View();
        }

        [HttpPost]
        public ActionResult Index(Reservation reservation)
        {
            reservation.dateReservation = DateTime.Now;
            //reservation.Email = Session["emails"].ToString();
            db.Reservations.Add(reservation);
            db.SaveChanges();
            return View();
        }


    }
}