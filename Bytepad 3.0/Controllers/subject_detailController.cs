using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bytepad_3._0.Models;

namespace Bytepad_3._0.Controllers
{
    public class subject_detailController : ApiController
    {
        private ISubject _subject = null;

        public subject_detailController(ISubject subject)
        {
            _subject = subject;
        }

        // Gets list of all subjects on the client side so that it can be used in search on frontend.
        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/subject_detail")]
        public IHttpActionResult GetSubjects()
        {
            List<Subject> dataAllSubjects = _subject.GetAllSubjects();
            return Ok(dataAllSubjects);
        }
    }
}
