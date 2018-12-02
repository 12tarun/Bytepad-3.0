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
    public class get_list_Controller : ApiController
    {
        private IPaper _paper = null;

        public get_list_Controller(IPaper paper)
        {
            _paper = paper;
        }

        // When in search box a subject is searched and selected, this controller brings all the subjects corresponding to the id of selected subject.
        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/get_list_")]
        public IHttpActionResult GetPapers(int subject_id)
        {
            List<Paper> papersOfSameSubject = _paper.FindPapersBySubjectId(subject_id); 
            return Ok(papersOfSameSubject);
        }
    }
}
