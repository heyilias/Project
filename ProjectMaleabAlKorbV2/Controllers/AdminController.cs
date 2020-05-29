using Newtonsoft.Json;
using ProjectMaleabAlKorbV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMaleabAlKorbV2.Controllers
{
    
    public class AdminController : Controller
    {
        
        MalaebAlKorbEntities db = new MalaebAlKorbEntities();

        //login for admin
        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(Admin admin)
        {
            var adm = db.Admins.Where(a => a.Emails == admin.Emails && a.Passwords == admin.Passwords).FirstOrDefault();
            if (adm != null)
            {
                Session["emailAdmin"] = admin.Emails;
                Session["passadmin"] = admin.Passwords;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }


        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("LoginAdmin", "Admin");
        }

        // GET: Dashboard
        
        public ActionResult Index()
        {
            
            if (Session["emailAdmin"] != null)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
            
        }
        //Test Players 
        public ActionResult Registers()
        {
            if (Session["emailAdmin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
        }


        //Nombre Players 
        public JsonResult CountPlayer()
        {
            var countPlayer = db.Players.Count();
            return Json(countPlayer, JsonRequestBehavior.AllowGet);
        }

        //Nombre Contact 
        public JsonResult CountContact()
        {
            var countctn = db.Contacts.Count();
            return Json(countctn, JsonRequestBehavior.AllowGet);
        }
        //Nombre Stadium 
        public JsonResult CountStadium()
        {
            var countStd = db.Stadia.Count();
            return Json(countStd, JsonRequestBehavior.AllowGet);
        }

        //Show all players in table registers
        public JsonResult GetPlyarsList()
        {
            List<Player> playerList = db.Players.ToList<Player>();
            
            return Json(playerList, JsonRequestBehavior.AllowGet);
        }
       
        
        //ADD PLAYERS
        public JsonResult SaveDataInDatabase(Player model)
        {
            var result = false;
            if (ModelState.IsValid)
                try
                {
                    if (model.playerNo > 0)
                    {
                        Player player = db.Players.Where(p =>p.playerNo == model.playerNo).FirstOrDefault();
                        player.names = model.names;
                        player.emails = model.emails;
                        player.passwords = model.passwords;
                        player.phone = model.phone;
                        db.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        model.dateCreated = DateTime.Now;
                        db.Players.Add(model);
                        db.SaveChanges();
                        result = true;
                    }
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Update Player
        public JsonResult GetPlayerById(int playerNo)
        {
            Player model = db.Players.Where(x => x.playerNo == playerNo).FirstOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        //Delete Player
        public JsonResult DeletePlayer(int playerNo)
        {
            bool result = false;
            Player player = db.Players.Where(p => p.playerNo == playerNo ).FirstOrDefault();
            if (player != null)
            {
                //player.dateCreated = DateTime.Now;
                db.Players.Remove(player);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /***********************Reservation**********************************/
        public ActionResult Reservations()
        {
            if (Session["emailAdmin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
        }

        //Show all Reservation 
        public JsonResult GetReservationList()
        {
            List<Reservation> resList = db.Reservations.ToList<Reservation>();

            return Json(resList, JsonRequestBehavior.AllowGet);
        }

        //ADD PLAYERS
        public JsonResult SaveDataInDatabaseReservation(Reservation model)
        {
            var result = false;
            if (ModelState.IsValid)
                try
                {
                    if (model.reservationNo > 0)
                    {
                        Reservation res = db.Reservations.Where(r => r.reservationNo == model.reservationNo).FirstOrDefault();
                        res.reservationTime = model.reservationTime;
                        res.reservationDate = model.reservationDate;
                        res.dateReservation = DateTime.Now;
                        res.Phone = model.Phone;
                        res.Email = model.Email;
                        res.nbrPlayer = model.nbrPlayer;
                        res.Location = model.Location;
                        db.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        model.dateReservation = DateTime.Now;
                        db.Reservations.Add(model);
                        db.SaveChanges();
                        result = true;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Update Reservation
        public JsonResult GetResById(int resNo)
        {
            Reservation model = db.Reservations.Where(r => r.reservationNo == resNo).FirstOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        //Delete Reservation
        public JsonResult DeleteRes(int resID)
        {
            bool result = false;
            Reservation res = db.Reservations.Where(r => r.reservationNo == resID).FirstOrDefault();
            if (res != null)
            {
                //player.dateCreated = DateTime.Now;
                db.Reservations.Remove(res);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /***********************Contact**********************************/
        public ActionResult Contact()
        {
            if (Session["emailAdmin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
        }
        
        public JsonResult GetContactList()
        {
            List<Contact> ContactList = db.Contacts.ToList<Contact>();

            return Json(ContactList, JsonRequestBehavior.AllowGet);
        }

    //ADD Contact
    public JsonResult SaveDataInDatabaseContact(Contact model)
        {
            var result = false;
            if (ModelState.IsValid)
                try
                {
                    if (model.messageNo > 0)
                    {
                        Contact player = db.Contacts.Where(p => p.messageNo == model.messageNo).FirstOrDefault();
                        player.name = model.name;
                        player.emails = model.emails;
                        player.allMessage = model.allMessage;
                        db.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        model.dateMessage = DateTime.Now;
                        db.Contacts.Add(model);
                        db.SaveChanges();
                        result = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Update Contact
        public JsonResult GetContactById(int msgNo)
        {
            Contact model = db.Contacts.Where(x => x.messageNo == msgNo).FirstOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        // Delete contact
        public JsonResult DeleteeContact(int msgNo)
        {
            bool result = false;
            Contact cnt = db.Contacts.Where(c => c.messageNo == msgNo).FirstOrDefault();
            if (cnt != null)
            {
                
                db.Contacts.Remove(cnt);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /***********************Staduim****************************/
        public ActionResult Stadium()
        {
            if (Session["emailAdmin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Admin");
            }
        }
        //show the list
        public JsonResult GetStadiumList()
        {
            List<Stadium> stadiumList = db.Stadia.ToList<Stadium>();

            return Json(stadiumList, JsonRequestBehavior.AllowGet);
        }

        //ADD Contact
        public JsonResult SaveDataInStadiumTable(Stadium model)
        {
            var result = false;
            if (ModelState.IsValid)
                try
                {
                    if (model.stadiumNo > 0)
                    {
                        Stadium stadium = db.Stadia.Where(s => s.stadiumNo == model.stadiumNo).FirstOrDefault();
                        stadium.stadiumName = model.stadiumName;
                        stadium.stadiumCity = model.stadiumCity;
                        stadium.stadiumCapacity = model.stadiumCapacity;
                        db.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        
                        db.Stadia.Add(model);
                        db.SaveChanges();
                        result = true;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Update Stadium
        public JsonResult GetStadiumById(int stdID)
        {
            Stadium model = db.Stadia.Where(s => s.stadiumNo == stdID).FirstOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Delete Stadium
        public JsonResult DeleteStadium(int stadiumNo)
        {
            bool result = false;
            Stadium stadium = db.Stadia.Where(s => s.stadiumNo == stadiumNo).FirstOrDefault();
            if (stadium != null)
            {
                
                db.Stadia.Remove(stadium);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}