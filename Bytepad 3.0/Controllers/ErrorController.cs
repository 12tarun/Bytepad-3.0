using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bytepad_3._0.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            //Response.AddHeader("Content-Disposition",new System.Net.Mime.ContentDisposition {Inline=true,FileName="error.html" }.ToString());
            return File(Server.MapPath("~/index.html"),"text/html");

        }
    }
}