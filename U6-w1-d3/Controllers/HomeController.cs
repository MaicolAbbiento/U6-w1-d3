using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U6_w1_d3.Models;

namespace U6_w1_d3.Controllers
{
    public class HomeController : Controller
    {
        public List<Scarpa> scarpa = Scarpe.getScarpe();

        public ActionResult Index()
        {
            if ((List<Scarpa>)Session["scarpapresente"] != null)
            {
                scarpa = (List<Scarpa>)Session["scarpapresente"];
            }

            return View(scarpa);
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Scarpa dip, HttpPostedFileBase immagine, HttpPostedFileBase ImmaginiAggiuntiva1, HttpPostedFileBase ImmaginiAggiuntiva2)
        {
            if (immagine != null && ImmaginiAggiuntiva1 != null && ImmaginiAggiuntiva2 != null)
            {
                if (immagine.ContentLength > 0 && ImmaginiAggiuntiva1.ContentLength > 0 && ImmaginiAggiuntiva2.ContentLength > 0)
                {
                    string nomeFile = immagine.FileName;
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/FileUpload"), nomeFile);
                    immagine.SaveAs(pathToSave);
                    string nomeFile2 = ImmaginiAggiuntiva1.FileName;
                    string pathToSave2 = Path.Combine(Server.MapPath("~/Content/FileUpload"), nomeFile2);
                    immagine.SaveAs(pathToSave2);
                    string nomeFile3 = ImmaginiAggiuntiva2.FileName;
                    string pathToSave3 = Path.Combine(Server.MapPath("~/Content/FileUpload"), nomeFile3);
                    immagine.SaveAs(pathToSave3);
                    dip.Immagine = immagine.FileName;
                    dip.ImmaginiAggiuntiva1 = ImmaginiAggiuntiva1.FileName;
                    dip.ImmaginiAggiuntiva2 = ImmaginiAggiuntiva2.FileName;
                }
            }

            TempData["MessaggioDiConferma"] = "Persona inserita correttamente";

            Scarpe.addscarpa(dip);
            return RedirectToAction("Index");
        }

        public ActionResult admin(List<bool> check)

        {
            if (Session["scarpapresente"] != null)
            {
                scarpa = (List<Scarpa>)Session["scarpapresente"];
            }
            return View(scarpa);
        }

        public ActionResult cambiaStato(string parameter)
        {
            int ID = Convert.ToInt32(parameter);
            Scarpa scarpasel = scarpa.Find((a) => a.Id == ID);
            for (int i = 0; i <= scarpa.Count; i++)
            {
                if (scarpasel.Id == scarpa[i].Id)
                {
                    scarpa[i].Presente = !scarpa[i].Presente;
                    break;
                }
            };
            Session["scarpapresente"] = scarpa;

            return RedirectToAction("admin");
        }

        public ActionResult eliminadaldatabase(string parameter)
        {
            Scarpe.delete(Convert.ToInt32(parameter));
            return RedirectToAction("admin");
        }

        public ActionResult Details(int id)
        {
            Scarpa dattagli = scarpa.Find(x => x.Id == id);
            ViewBag.dettagli = dattagli;
            return View(dattagli);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Scarpa dattagli = scarpa.Find(x => x.Id == id);
            ViewBag.dettagli = dattagli;
            return View(dattagli);
        }

        [HttpPost]
        public ActionResult Edit(Scarpa p, HttpPostedFileBase immagine, HttpPostedFileBase ImmaginiAggiuntiva1, HttpPostedFileBase ImmaginiAggiuntiva2)
        {
            if (immagine != null && ImmaginiAggiuntiva1 != null && ImmaginiAggiuntiva2 != null)
            {
                if (immagine.ContentLength > 0 && ImmaginiAggiuntiva1.ContentLength > 0 && ImmaginiAggiuntiva2.ContentLength > 0)
                {
                    string nomeFile = immagine.FileName;
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/FileUpload"), nomeFile);
                    immagine.SaveAs(pathToSave);
                    string nomeFile2 = ImmaginiAggiuntiva1.FileName;
                    string pathToSave2 = Path.Combine(Server.MapPath("~/Content/FileUpload"), nomeFile2);
                    immagine.SaveAs(pathToSave2);
                    string nomeFile3 = ImmaginiAggiuntiva2.FileName;
                    string pathToSave3 = Path.Combine(Server.MapPath("~/Content/FileUpload"), nomeFile3);
                    immagine.SaveAs(pathToSave3);
                    p.Immagine = immagine.FileName;
                    p.ImmaginiAggiuntiva1 = ImmaginiAggiuntiva1.FileName;
                    p.ImmaginiAggiuntiva2 = ImmaginiAggiuntiva2.FileName;
                }
            }
            Scarpe.elimica(p);
            return View(p);
        }
    }
}