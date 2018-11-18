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

        public AddpapersController(IExamType examType, ISession session, ISemester semester)
        {
            _examType = examType;
            _session = session;
            _semester = semester;
        }

        // GET: Addpapers
        [HttpGet]
        public ActionResult Upload()
        {
            ViewBag.examType = _examType.GetAllExamTypes();
            ViewBag.session = _session.GetAllSessions();
            ViewBag.semester = _semester.GetAllSemesters();
            return View();
        }

        [HttpPost]
        public ActionResult Upload(Paper objPaper, List<HttpPostedFileBase> listOfPapers)
        {
            List<string> listOfRejectedFiles = new List<string>();
        //  bool isFillPaper = // fill paper ke interface se interaction ??   objFillPaper.filledPapers();
            
            return RedirectToAction("Upload");
        }
    }
}