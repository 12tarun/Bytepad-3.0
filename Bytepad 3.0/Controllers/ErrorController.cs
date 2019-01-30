using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bytepad_3._0.Controllers
{
    public class ErrorController : Controller
    {
        // Returns to bytepad.silive.in when bytepad.silive.in/xyz.... is requested.
        public ActionResult NotFound()
        {
            return File(Server.MapPath("~/index.html"),"text/html");
        }
    }
}