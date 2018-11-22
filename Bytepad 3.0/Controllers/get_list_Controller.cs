using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        [HttpGet]
        public IHttpActionResult GetPapers(int id)
        {
            List<Paper> papersOfSameSubject = _paper.FindPapersBySubjectId(id); 
            return Ok(papersOfSameSubject);
        }
    }
}
