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
        public ActionResult Upload()
        {

            IExamType _examType = new 
            return View();
        }
    }
}