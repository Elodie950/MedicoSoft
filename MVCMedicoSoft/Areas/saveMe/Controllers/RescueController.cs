using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMedicoSoft.Areas.saveMe.Controllers
{
    public class RescueController : Controller
    {
        //
        // GET: /saveMe/Rescue/

        public ActionResult Name()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Name(string num)
        {
            ViewBag.step = 3;
            Personne p = Personne.getInfo(num);
            string NomMedecin = "";
            if (p != null)
            {
                if (p.getReferent(out NomMedecin) != null)
                {
                    return View("Localise", p);
                }
                else
                {
                    return View("Death", p);
                }
            }
            else
            {
                return View("Death", p);
            }
        }

    }
	
}