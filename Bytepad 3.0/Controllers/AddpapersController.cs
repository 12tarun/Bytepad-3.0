using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytepad_3._0.Models;

namespace Bytepad_3._0.Controllers
{
    public class AddpapersController : Controller
    {
        private IExamType _examType = null;
        private ISession _session = null;
        private ISemester _semester = null;
        private IFillPaper _fillPaper = null;
        private IVersion _version = null;

        public AddpapersController(IExamType examType, ISession session, ISemester semester, IFillPaper fillPaper,IVersion version)
        {
            _examType = examType;
            _session = session;
            _semester = semester;
            _fillPaper = fillPaper;
            _version = version;
        }

        // GET: Addpapers
        [HttpGet]
        [Authorize]
        public ActionResult Upload()
        {
            ViewBag.examType = _examType.GetAllExamTypes();
            ViewBag.session = _session.GetAllSessions();
            ViewBag.semester = _semester.GetAllSemesters();
            if (TempData["failure"] != null)
            {
                ViewBag.rejectedFiles = TempData["failure"];
            }
            return View();
        }

        // POST: Addpapers
        [HttpPost]
        public ActionResult Upload(Paper objPaper, List<HttpPostedFileBase> ListOfPaper)
        {
            List<string> listOfRejectedFiles = new List<string>();
            _fillPaper.FilledPapers(objPaper, ListOfPaper, out listOfRejectedFiles);
            TempData["success"] = "Successfully Added!";
            TempData["failure"] = listOfRejectedFiles;
            _version.updateLastAddPaperTime();
            return RedirectToAction("Upload");
        }
    }
}