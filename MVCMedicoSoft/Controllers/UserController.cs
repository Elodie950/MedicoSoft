using DAL;
using MVCMedicoSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMedicoSoft.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
         [HttpGet]
        public ActionResult AfficherUsers()
        {
            if (MySession.Login == null) return RedirectToRoute(new { controller = "Home", action = "Index" });
            List<Utilisateur> lu = Utilisateur.getInfos();

            //if (MySession.User.getRole() == TypeOfUser.Medecin)
            //    MySession.isMedecin = true;
            //else {
            //    MySession.isMedecin = false;
            //} OU
            MySession.isMedecin = MySession.User.getRole() == TypeOfUser.Medecin;

            return View(lu);
             /*
            if (MySession.Login == null)
            {
                return RedirectToRoute(new { Controller = "Login", action = "Forms" });
            }
            else
            {
                List<Utilisateur> maListe = Utilisateur.getInfos();
                return View(maListe);
            }*/
            
        }

        
        
         public ActionResult DetailsUser(int id)
         {
             Utilisateur u = Utilisateur.getInfo(id);
             
             return View(u as Personne);
         }

        
        
        [HttpGet]
         public ActionResult EditUser(string id)
         {
                 Personne p = Personne.getInfo(id);
                 return View(p);
         }

        
        
        [HttpPost]
        public ActionResult EditUser(Personne p)
        {
            p.saveMe();
            return View(p);
        }



        public ActionResult AfficherPatient()
        {
            //Si on n'est pas loggué, on redirige vers la home
            if (MySession.Login == null) return RedirectToRoute(
                    new { controller = "Home", action = "Index" });
            Medecin me = MySession.User.ConvertMedecin();

            return View(me.getListePatient());
 
        }
	}
}