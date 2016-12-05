using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class ResultsController : Controller
    {
        ResultsController()
        {
            filePath = Server.MapPath("~/Files/DownloadFile.bin");
        }
        public readonly string filePath;//AppDomain.CurrentDomain.BaseDirectory + "/App_Data/DownloadFile.bin";
        public ViewResult Index()
        {
            return View();
        }
        public FileResult fileResult()
        {
            return File(filePath, "application/octet-stream");
        }

        public FileContentResult fileContentResult()
        {
            byte[] mas = System.IO.File.ReadAllBytes(filePath);
            return File(mas, "application/octet-stream", "DownloadFile.bin");
        }
        public FilePathResult filePathResult()
        {
            return File(filePath, "application/octet-stream");
        }
        public FileStreamResult fileStreamResult()
        {
            FileStream sr = new FileStream(filePath, FileMode.OpenOrCreate);

            return File(sr, "text/plain");
        }
        public HttpStatusCodeResult httpStatusCodeResult()
        {
            return new HttpNotFoundResult();
        }

        //DOESN'T WORK
        public HttpUnauthorizedResult httpUnauthorizedResult()
        {
            return new HttpUnauthorizedResult();
        }
        public HttpNotFoundResult httpNotFoundResult()
        {
            return new HttpNotFoundResult();
        }

        //DOESN'T WORK
        public ActionResult javaScriptResult()
        {
            return JavaScript("");
        }

        //DOESN'T WORK
        public JsonResult jsonResult()
        {
            string[] obj = { "Json Object1", "Json Object2" };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult partialViewResult()
        {
            return PartialView();
        }
        public RedirectResult redirectResult()
        {
            return Redirect("http://webdesign.about.com/od/multimedia/a/mime-types-by-content-type.htm");
        }

        public RedirectToRouteResult redirectToRouteResult()
        {
            return RedirectToAction("Index");
        }

        public EmptyResult emptyResult()
        {
            Response.Write(Request.UserHostAddress);
            return new EmptyResult();
        }


    }
}