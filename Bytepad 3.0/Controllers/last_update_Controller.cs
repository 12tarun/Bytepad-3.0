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
    public class last_update_Controller : ApiController
    {
        IVersion _version=null;

        public last_update_Controller(IVersion version)
        {
            _version = version;
        }

        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/last_update_")]
        public DateTime? date_time()
        {
            return _version.getLastAddPaperTime();
        }
    }
}
