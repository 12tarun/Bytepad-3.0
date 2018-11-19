using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using Bytepad_3._0.Models;
=======
>>>>>>> origin/adminLogin

namespace Bytepad_3._0.Controllers
{
    public class AddpapersController : Controller
    {
<<<<<<< HEAD
        private IExamType _examType = null;
        private ISession _session = null;
        private ISemester _semester = null;
        private IFillPaper _fillPaper = null;

        public AddpapersController(IExamType examType, ISession session, ISemester semester, IFillPaper fillPaper)
        {
            _examType = examType;
            _session = session;
            _semester = semester;
            _fillPaper = fillPaper;
        }

        // GET: Addpapers
        [HttpGet]
        public ActionResult Upload()
        {
            ViewBag.examType = _examType.GetAllExamTypes();
            ViewBag.session = _session.GetAllSessions();
            ViewBag.semester = _semester.GetAllSemesters();
            if(TempData["failure"]!=null)
            {
                ViewBag.rejectedFiles = TempData["failure"];
            }
            return View();
        }

        // POST: Addpapers
        [HttpPost]
        public ActionResult Upload(Paper objPaper, List<HttpPostedFileBase> listOfPapers)
        {
            List<string> listOfRejectedFiles = new List<string>();
            _fillPaper.FilledPapers(objPaper, listOfPapers, out listOfRejectedFiles);
            TempData["success"] = "Successfully Added!";
            TempData["failure"] = listOfRejectedFiles;
            return RedirectToAction("Upload");

            // view mein thoda code bacha hai..
        }
=======
        // GET: Addpapers
        public ActionResult Index()
        {
            return View();
        }
>>>>>>> origin/adminLogin
    }
}