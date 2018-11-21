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
        public ViewpapersController(IPaperViewModel paperViewModel)
        {
            _paperViewModel = paperViewModel;
        }
        // GET: Viewpapers
        public ActionResult Index()
        {
            ViewBag.listOfPapers = _paperViewModel.getAllPapers();
            return View();
        }

    }
}