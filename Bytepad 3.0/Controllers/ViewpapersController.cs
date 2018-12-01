using Bytepad_3._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bytepad_3._0.Controllers
{
    public class ViewpapersController : Controller
    {
        IPaperViewModel _paperViewModel = null;
        IPaper _paper = null;
        public ViewpapersController(IPaperViewModel paperViewModel,IPaper paper)
        {
            _paperViewModel = paperViewModel;
            _paper = paper;
        }
        // GET: Viewpapers
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.listOfPapers = _paperViewModel.getAllPapers();
            return View();
        }
        public void viewPaper(string FileUrl)
        {
            string url = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpRuntime.AppDomainAppVirtualPath + ("Papers")+"\\"+FileUrl;
            url = url.Replace("\\", "/");
            System.Web.HttpContext.Current.Response.Redirect("https://docs.google.com/viewer?url="+url);
        }
        public ActionResult removePaper(int id)
        {
            _paper.DeletePaperByID(id);
            ViewBag.listOfPapers = _paperViewModel.getAllPapers();
            return RedirectToAction("Index");
        }
    }
}